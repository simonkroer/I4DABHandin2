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
        public virtual List<Person> Personer { get; set; } = new List<Person>();
    }
}
