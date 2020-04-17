using Ecommerce.BLL.Abstractions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class CustomerTypeManager:ICustomerTypeManager
    {
        ICustomerTypeRepository _customerTypeRepository;
        public CustomerTypeManager(ICustomerTypeRepository customerTypeRepo)
        {
            _customerTypeRepository = customerTypeRepo;
        }
        public ICollection<CustomerType> GetAll()
        {
            return _customerTypeRepository.GetAll();
        }
    }
}
