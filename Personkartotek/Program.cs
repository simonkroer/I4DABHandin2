using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2
{
    class Program
    {
        static void Main(string[] args)
        {
            var SimonsPersonkartok = new Personkartotek();

            var Adam = new Person() {PersonId = 1, fornavn = "Adam", mellemnavn = "Tobias", efternavn = "Niklassen",email = "adam@gmail.com"};
            var Maja = new Person() {PersonId = 2};
            var AdamOgMajasHus = new Adresse() {by = "Aarhus V", land = "Danmark",postnummer = "8210", vejnavn = "Finlandsgade",vejnummer=21};
            var MajasSommerhus = new Adresse() { by = "Marienlyst", land = "Danmark", postnummer = "8100", vejnavn = "Fuglesangs Allé", vejnummer = 20 };
            var Fotex = new AlternativAdresse() { by = "Aarhus V", land = "Danmark", postnummer = "8210", vejnavn = "Finlandsgade", vejnummer = 40 ,type = "arbejde"};

            var AdamsArbTlf = new Telefon() {nummer = "40859217",teleselskab = "Telia",type = "Arbejde"};
            var AdamOgMajaTlf = new Telefon() { nummer = "50859217", teleselskab = "Telia", type = "Hjem" };

            
            Adam.primAdresse = AdamOgMajasHus;
            Adam.altAdresse.Add(Fotex);

            SimonsPersonkartok.Personer.Add(Adam);
            SimonsPersonkartok.Personer.Add(Maja);

        }
    }

    public class Personkartotek
    {
        public List<Person> Personer = new List<Person>();
    }


    public class Person
    {

        public int PersonId { get; set; }
        public string fornavn { get; set; }
        public string mellemnavn { get; set; }
        public string efternavn { get; set; }
        public string email { get; set; }
        public string type { get; set; }

        public Adresse primAdresse { get; set; }
        public List<AlternativAdresse> altAdresse = new List<AlternativAdresse>();
    }

    public class Adresse
    {
        public string by { get; set; }
        public string land { get; set; }
        public string postnummer { get; set; }
        public string vejnavn { get; set; }
        public int vejnummer { get; set; } 
    }


    public class AlternativAdresse : Adresse
    {
        public string type { get; set; }
    }

    public class Telefon
    {
        public string nummer { get; set; }
        public string type { get; set; }
        public string teleselskab { get; set; }
    }
}
