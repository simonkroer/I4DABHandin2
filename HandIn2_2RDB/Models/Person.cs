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
        public virtual List<AlternativAdresse> altAdresse { get; set; } = new List<AlternativAdresse>();
        public virtual List<Telefon> telefoner { get; set; } = new List<Telefon>();
    }
}
