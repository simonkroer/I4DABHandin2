using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2_2RDB.Models
{
    public class AlternativAdresse
    {
        [Key]
        public int altAdresseId { get; set; }
        public string by { get; set; }
        public string land { get; set; }
        public string postnummer { get; set; }
        public string vejnavn { get; set; }
        public int vejnummer { get; set; }
        public string type { get; set; }
    }
}
