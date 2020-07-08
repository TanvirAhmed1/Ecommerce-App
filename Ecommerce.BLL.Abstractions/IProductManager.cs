using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions
{
    public interface IProductManager
    {
        bool Add(Product entity);
        bool Update(Product entity);
        bool Remove(Product entity);
        ICollection<Product> GetAll();
        Product GetById(int? id);
    }
}
