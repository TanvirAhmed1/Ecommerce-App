﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.BLL.Abstractions.Base
{
    public interface IManager<T> where T : class
    {
        bool Add(T enitity);
        bool Update(T enitity);
        bool Remove(T enitity);
        ICollection<T> GetAll();
        T GetFirstorDefault(Expression<Func<T, bool>> predicate);
    }
}
