using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Ecommerce.Repositories.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetById(int? id);
        ICollection<Customer> GetByRequest(CustomerRequestModel customer);
    }
}
