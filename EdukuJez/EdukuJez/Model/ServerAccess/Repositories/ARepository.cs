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
        public DbSet<T> Table { get; protected set; }
        protected BaseContext Context { get; }
        public ARepository()
        {
            Context = BaseContext.GetContext();
        }
        virtual public void Insert(T entity)
        {
            if (entity == null)
                return;
            Context.Add(entity);
            Context.SaveChanges();
        }
        virtual public void Delete(T entity)
        {
            if (entity == null)
                return;
            Context.Remove(entity);
            Context.SaveChanges();
        }
        virtual public void Update()
        {
            Context.SaveChanges();
        }
        virtual public void UpdateRow(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
    }
}
