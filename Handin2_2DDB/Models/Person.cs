using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Handin2_2DDB.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string ForNavn { get; set; }
        public string MellemNavn { get; set; }
        public string EfterNavn { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public Adresse PrimAdresse { get; set; }

        public Collection<AlternativAdresse> AltAdresser { get; set; }
        public Collection<Telefon> Telefoner { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}. Email: {3} Telefonnumre: {4}", ForNavn,MellemNavn, EfterNavn, Email,
                Telefoner.Any() ? string.Join(",", Telefoner.Select(t => t.nummer)) : "-");
        }

    }
}
