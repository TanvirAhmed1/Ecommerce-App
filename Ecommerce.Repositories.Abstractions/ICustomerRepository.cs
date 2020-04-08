using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        bool Add(Customer entity);
        bool Update(Customer entity);
        bool Remove(Customer entity);
        ICollection<Customer> GetAll();
        Customer GetById(int? id);
    }
}
