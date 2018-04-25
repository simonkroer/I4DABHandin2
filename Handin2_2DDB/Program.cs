using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using DocumentDB.Repository;
using Handin2_2DDB.Persistence.Repositories;
using Handin2_2DDB.Core.Domain;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Client.TransientFaultHandling;
using Newtonsoft.Json;

namespace Handin2_2DDB
{
    class Program
    {
        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public static IReliableReadWriteDocumentClient Client { get; set; }

        static void Main(string[] args)
        {
            try
            {
                IDocumentDbInitializer init = new DocumentDbInitializer();

                Client = init.GetClient(EndpointUrl, PrimaryKey);

                Program p = new Program();
                p.DocumentDBDemoWithUOW().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("Demo is Done. Press any key to continue");
                Console.ReadKey();
            }
        }

        private async Task DocumentDBDemoWithUOW()
        {
            using (var UOW = new UnitOfWork(new PersonRepository(Client, "Personkartotek")))
            {
                var person1 = new Person()
                {
                    Id = "1",
                    ForNavn = "Adam",
                    MellemNavn = "Tobias",
                    EfterNavn = "Niklassen",
                    Email = "adam@gmail.com",
                    Type = "Ven",

                    PrimAdresse = new Adresse()
                    {
                        by = "Aarhus V",
                        land = "Danmark",
                        postnummer = "8210",
                        vejnavn = "Finlandsgade",
                        vejnummer = 21
                    },

                    AltAdresser = new Collection<AlternativAdresse>
                {
                    new AlternativAdresse()
                    {
                        by = "Marienlyst",
                        land = "Danmark",
                        postnummer = "8100",
                        vejnavn = "Fuglesangs Allé",
                        vejnummer = 20,
                        type = "Sommerhus"
                    },

                    new AlternativAdresse()
                    {
                        by = "Aarhus V",
                        land = "Danmark",
                        postnummer = "8210",
                        vejnavn = "Finlandsgade",
                        vejnummer = 40,
                        type = "arbejde"
                    },
                },

                    Telefoner = new Collection<Telefon>
                {
                    new Telefon {nummer = "40829348",teleselskab = "Telia",type = "Mobil"},
                    new Telefon {nummer = "60483959",teleselskab = "3",type = "Arbejde"},
                }
                };


                var person2 = new Person()
                {
                    Id = "2",
                    ForNavn = "Maja",
                    MellemNavn = "",
                    EfterNavn = "Henriksen",
                    Email = "maja@gmail.com",
                    Type = "Veninde",

                    PrimAdresse = new Adresse()
                    {
                        by = "Aarhus N",
                        land = "Danmark",
                        postnummer = "8200",
                        vejnavn = "Randersvej",
                        vejnummer = 25
                    },

                    AltAdresser = new Collection<AlternativAdresse>()
                {
                    new AlternativAdresse()
                    {
                        by = "Marienlyst",
                        land = "Danmark",
                        postnummer = "8100",
                        vejnavn = "Fuglesangs Allé",
                        vejnummer = 20,
                        type = "Sommerhus"
                    },

                    new AlternativAdresse()
                    {
                        by = "Aarhus V",
                        land = "Danmark",
                        postnummer = "8210",
                        vejnavn = "Finlandsgade",
                        vejnummer = 40,
                        type = "Forældre"
                    },

                    new AlternativAdresse()
                    {
                        by = "Aarhus",
                        land = "Danmark",
                        postnummer = "8000",
                        vejnavn = "Klostertorvet",
                        vejnummer = 10,
                        type = "arbejde"
                    },
                },


                    Telefoner = new Collection<Telefon>
                {
                    new Telefon {nummer = "40669348",teleselskab = "Telenor",type = "Hjem"},
                    new Telefon {nummer = "66483959",teleselskab = "Oister",type = "Mobil"},
                }
                };
                //Create 2 persons
                await UOW.PersonRepo.CreatePerson(person1);

                await UOW.PersonRepo.CreatePerson(person2);

                //print collection
                await UOW.PersonRepo.PrintPersonCollection();

                //change person1's name
                person1.ForNavn = "Henning";

                //Update name in DB
                await UOW.PersonRepo.UpdatePerson(person1);

                //Print with updated name
                await UOW.PersonRepo.PrintPersonCollection();

                //Read person1 to person3
                var person3 = await UOW.PersonRepo.ReadPerson("1");

                //Update person3's ID
                person3.Id = "3";

                //create person3 in DB
                await UOW.PersonRepo.CreatePerson(person3);

                //Print collection with person3 (same as person1, except different ID)
                await UOW.PersonRepo.PrintPersonCollection();

                //delete person3
                await UOW.PersonRepo.DeletePerson("3");

                await UOW.PersonRepo.PrintPersonCollection();

                await UOW.PersonRepo.DeletePerson("1");

                await UOW.PersonRepo.DeletePerson("2");

                await UOW.PersonRepo.PrintPersonCollection();
            }
 
        }
    }
}
