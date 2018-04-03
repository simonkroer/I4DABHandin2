using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Handin2_2DDB.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public int PersonId { get; set; }

        [JsonProperty("forNavn")]
        public string ForNavn { get; set; }

        [JsonProperty("mellemNavn")]
        public string MellemNavn { get; set; }

        [JsonProperty("efterNavn")]
        public string EfterNavn { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("primAdresse")]
        public Adresse PrimAdresse { get; set; }

        [JsonProperty("altAdresse")]
        public List<AlternativAdresse> AltAdresse = new List<AlternativAdresse>();

        [JsonProperty("telefoner")]
        public List<Telefon> Telefoner = new List<Telefon>();

    }
}
