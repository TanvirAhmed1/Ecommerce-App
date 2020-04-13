using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Repositories.Abstractions.Base
{
    public interface IRepository<T> where T:class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        ICollection<T> GetAll();
        T GetFirstOfDefault(Expression<Func<T,bool>>predicate);
    }
}
