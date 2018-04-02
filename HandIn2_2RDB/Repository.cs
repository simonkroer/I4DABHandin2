using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace HandIn2_2RDB
{
    public class Repository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
        }

        public T Read(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T t)
        {
            _context.Set<T>().AddOrUpdate(t);
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
        }
    }
}
