using Ecommerce.BLL.Abstractions;
using Ecommerce.BLL.Abstractions.Base;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{

    public class CustomerManager : Manager<Customer>, ICustomerManager
    {
        ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerManager) : base(customerManager)
        {
            _customerRepository = customerManager;
        }

        public Customer GetById(int? id)
        {
            if (id != null)
            {
                return _customerRepository.GetById(id);
            }
            return null;
        }

        public ICollection<Customer> GetByRequest(CustomerRequestModel customer)
        {
            return _customerRepository.GetByRequest(customer);
        }
    }
}
