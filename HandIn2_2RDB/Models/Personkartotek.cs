using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2_2RDB.Models
{
    public class Personkartotek
    {
        public int personKartotekId { get; set; }
        public List<Person> Personer = new List<Person>();
    }
}
