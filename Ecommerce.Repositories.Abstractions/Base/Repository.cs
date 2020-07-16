using Ecommerce.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Repositories.Abstractions.Base
{
    public abstract class Repository<T>:IRepository<T> where T : class
    {
        DbContext _db;
        private DbSet<T> Table{
            get
            {
                return _db.Set<T>();
            }
        }

        public Repository(DbContext db)
        {
            _db = db;
        }
        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return _db.SaveChanges() > 0;

        }
        public virtual bool Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }
        public virtual bool Remove(T entity)
        {
            if(entity is IDeletable)
            {
                var thisEntity = (IDeletable)entity;
                thisEntity.Delete();
                return Update(entity);
            }
            else
            {
                Table.Remove(entity);
                return _db.SaveChanges() > 0;
            }
        }
        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }
        public virtual T GetFirstOrDefault(Expression<Func<T,bool>>predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        
    }
}
