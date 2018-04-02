using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2_2RDB.Models
{
    public class Person
    {

        public int personId { get; set; }
        public string fornavn { get; set; }
        public string mellemnavn { get; set; }
        public string efternavn { get; set; }
        public string email { get; set; }
        public string type { get; set; }

        public Adresse primAdresse { get; set; }
        public List<AlternativAdresse> altAdresse = new List<AlternativAdresse>();
        public List<Telefon> telefoner = new List<Telefon>();
    }
}
