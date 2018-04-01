using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HandIn2_2RDB.Models;

namespace HandIn2_2RDB
{
    public class RdbContext : DbContext
    {
        public DbSet<Adresse> Adresser { get; set; }
        public DbSet<AlternativAdresse> AlternativeAdresser { get; set; }
        public DbSet<Person> Personer { get; set; }
        public DbSet<Personkartotek> Personkartoteker { get; set; }
        public DbSet<Telefon> Telefoner { get; set; }
    }
}
