using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HandIn2_2RDB
{
    public class UnitOfWork
    {
        public DbContext Context { get; set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Complete()
        {
            Context.SaveChanges();
        }
    }
}
