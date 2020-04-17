using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions
{
    public interface ICustomerTypeManager
    {
        public ICollection<CustomerType>GetAll();
    }
}
