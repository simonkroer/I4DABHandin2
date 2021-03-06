﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn2_2RDB;
using HandIn2_2RDB.Models;
using System.Data.Entity;


namespace MainRDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RdbContext();
            var UOW = new UnitOfWork(context);
            var adresseRepo = new Repository<Adresse>(context);
            var altAdresseRepo = new Repository<AlternativAdresse>(context);
            var personRepo = new Repository<Person>(context);
            var personKartRepo = new Repository<Personkartotek>(context);
            var telefonRepo = new Repository<Telefon>(context);

            var SimonsPersonkartok = new Personkartotek();
            var AdamOgMajasHus = new Adresse() { by = "Aarhus V", land = "Danmark", postnummer = "8210", vejnavn = "Finlandsgade", vejnummer = 21 };
            var MajasSommerhus = new AlternativAdresse() { by = "Marienlyst", land = "Danmark", postnummer = "8100", vejnavn = "Fuglesangs Allé", vejnummer = 20, type = "Sommerhus" };
            var Fotex = new AlternativAdresse() { by = "Aarhus V", land = "Danmark", postnummer = "8210", vejnavn = "Finlandsgade", vejnummer = 40, type = "arbejde" };
            var AdamsArbTlf = new Telefon() { nummer = "40859217", teleselskab = "Telia", type = "Arbejde" };
            var AdamOgMajaTlf = new Telefon() { nummer = "50859217", teleselskab = "Telia", type = "Hjem" };
            var Adam = new Person() { personId = 1, fornavn = "Adam", mellemnavn = "Tobias", efternavn = "Niklassen", email = "adam@gmail.com", type = "Ven", telefoner = new List<Telefon>(){AdamOgMajaTlf, AdamsArbTlf}, altAdresse = new List<AlternativAdresse>(){Fotex}};
            var Maja = new Person() { personId = 2, fornavn = "Maja", mellemnavn = "Mus", efternavn = "Hansen", email = "hej@hej.dk", type = "Veninde", telefoner = new List<Telefon>(){AdamOgMajaTlf}, altAdresse = new List<AlternativAdresse>(){MajasSommerhus}};

            Console.WriteLine("Creating");
            Console.WriteLine();

            personKartRepo.Create(SimonsPersonkartok);
            personRepo.Create(Adam);
            personRepo.Create(Maja);
            adresseRepo.Create(AdamOgMajasHus);
            altAdresseRepo.Create(MajasSommerhus);
            altAdresseRepo.Create(Fotex);
            telefonRepo.Create(AdamsArbTlf);
            telefonRepo.Create(AdamOgMajaTlf);

            UOW.Complete();

            Console.WriteLine("UOW - Complete");
            Console.WriteLine();

            Console.WriteLine("Reading");
            Console.WriteLine();

            

            Adam = personRepo.Read(Adam.personId);
            Maja = personRepo.Read(Maja.personId);
            SimonsPersonkartok = personKartRepo.Read(SimonsPersonkartok.personKartotekId);

            printPerson(Adam, adresseRepo, AdamOgMajasHus);
            printPerson(Maja, adresseRepo, AdamOgMajasHus);

            Console.WriteLine();
            Console.WriteLine("Updating");
            Console.WriteLine();

            Adam.email = "lol@123.de";
            Adam.telefoner.Add(new Telefon(){nummer = "23456789", teleselskab = "CallMore", type = "iPhone"});
            Maja.email = "Maja@hej.dk";
            Maja.telefoner.Add(new Telefon() { nummer = "23456780", teleselskab = "CallMee", type = "iPhoneX" });
            personRepo.Update(Adam);
            personRepo.Update(Maja);
            personKartRepo.Update(SimonsPersonkartok);
            UOW.Complete();

            Console.WriteLine("UOW - Complete");
            Console.WriteLine();

            printPerson(Adam, adresseRepo, AdamOgMajasHus);
            printPerson(Maja, adresseRepo, AdamOgMajasHus);

            Console.WriteLine();
            Console.WriteLine("Deleting");
            Console.WriteLine();

            //personRepo.Delete(Adam);
            personRepo.Delete(Maja);
            
            UOW.Complete();
            Console.WriteLine("UOW - Complete");

            try
            {
                printPerson(Maja, adresseRepo, AdamOgMajasHus);
            }
            catch (Exception)
            {
                Console.WriteLine("Maja deleted");
            }

        }

        private static void printPerson(Person person, Repository<Adresse> addRepo, Adresse adresse)
        {
                Console.WriteLine("Navn: {0} {1} {2}", person.fornavn, person.mellemnavn, person.efternavn);
                Console.WriteLine("Type: {0}", person.type);
                Console.WriteLine("Email: {0}", person.email);
                Console.WriteLine("Primær adresse: {0} {1}", addRepo.Read(adresse.adresseId).vejnavn, addRepo.Read(adresse.adresseId).vejnummer);
                Console.WriteLine("By: {0}", addRepo.Read(adresse.adresseId).by);
                Console.WriteLine("Postnummer: {0}", addRepo.Read(adresse.adresseId).postnummer);
                Console.WriteLine("Land: {0}", addRepo.Read(adresse.adresseId).land);
                Console.WriteLine();

                foreach (var altAdresse in person.altAdresse)
                {
                Console.WriteLine("Alternativ adresse: {0} {1}", altAdresse.vejnavn, altAdresse.vejnummer);
                    Console.WriteLine("By: {0}", altAdresse.by);
                    Console.WriteLine("Postnummer: {0}", altAdresse.postnummer);
                    Console.WriteLine("Land: {0}", altAdresse.land);
                    Console.WriteLine("Type: {0}", altAdresse.type);
                    Console.WriteLine();
        }

                foreach (var telefon in person.telefoner)
                {
                    Console.WriteLine("Telefon:");
                    Console.WriteLine("Nummer: {0}", telefon.nummer);
                    Console.WriteLine("Teleselskab: {0}", telefon.teleselskab);
                    Console.WriteLine("Type: {0}", telefon.type);
                    Console.WriteLine();
                }

                Console.WriteLine();
        }
    }
}
