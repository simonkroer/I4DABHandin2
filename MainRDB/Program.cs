using System;
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
            var Adam = new Person() { PersonId = 1, fornavn = "Adam", mellemnavn = "Tobias", efternavn = "Niklassen", email = "adam@gmail.com" };
            var Maja = new Person() { PersonId = 2, fornavn = "Maja", mellemnavn = "Mus", efternavn = "Hansen", email = "hej@hej.dk"};
            var AdamOgMajasHus = new Adresse() { by = "Aarhus V", land = "Danmark", postnummer = "8210", vejnavn = "Finlandsgade", vejnummer = 21 };
            var MajasSommerhus = new AlternativAdresse() { by = "Marienlyst", land = "Danmark", postnummer = "8100", vejnavn = "Fuglesangs Allé", vejnummer = 20 };
            var Fotex = new AlternativAdresse() { by = "Aarhus V", land = "Danmark", postnummer = "8210", vejnavn = "Finlandsgade", vejnummer = 40, type = "arbejde" };
            var AdamsArbTlf = new Telefon() { nummer = "40859217", teleselskab = "Telia", type = "Arbejde" };
            var AdamOgMajaTlf = new Telefon() { nummer = "50859217", teleselskab = "Telia", type = "Hjem" };

            Adam.telefoner.Add(AdamsArbTlf);
            Adam.telefoner.Add(AdamOgMajaTlf);

            Maja.telefoner.Add(AdamOgMajaTlf);

            Adam.primAdresse = AdamOgMajasHus;
            Adam.altAdresse.Add(Fotex);

            Maja.primAdresse = AdamOgMajasHus;
            Maja.altAdresse.Add(MajasSommerhus);

            SimonsPersonkartok.Personer.Add(Adam);
            SimonsPersonkartok.Personer.Add(Maja);

            personKartRepo.Create(SimonsPersonkartok);
            personRepo.Create(Adam);
            personRepo.Create(Maja);
            adresseRepo.Create(AdamOgMajasHus);
            altAdresseRepo.Create(MajasSommerhus);
            altAdresseRepo.Create(Fotex);
            telefonRepo.Create(AdamsArbTlf);
            telefonRepo.Create(AdamOgMajaTlf);

            UOW.Complete();


            printPersonKartotek(SimonsPersonkartok);
        }
        private static void printPersonKartotek(Personkartotek personkartotek)
        {
            foreach (var person in personkartotek.Personer)
            {
                Console.WriteLine("Navn: {0} {1} {2}", person.fornavn, person.mellemnavn, person.efternavn);

            }
        }
    }
}
