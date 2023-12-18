using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez.Repositories
{
    public abstract class ARepository<T> where T : EntityBase
    {
        public  DbSet<T> Table { get; protected set; }
        protected BaseContext Context { get; }
        public ARepository()
        {
            Context = BaseContext.GetContext();
        }
        public void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

    }
}
