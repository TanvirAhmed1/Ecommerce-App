using Ecommerce.BLL.Abstractions.Base;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions
{
    public interface ICustomerManager : IManager<Customer>
    {

        Customer GetById(int? id);
        ICollection<Customer> GetByRequest(CustomerRequestModel customer);
    }
}
