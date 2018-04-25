using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handin2_2DDB.Core.Domain
{
    public class Adresse
    {
        public string by { get; set; }
        public string land { get; set; }
        public string postnummer { get; set; }
        public string vejnavn { get; set; }
        public int vejnummer { get; set; }
    }
}
