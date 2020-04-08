using Ecommerce.BLL.Abstractions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    
    public class CustomerManager:ICustomerManager
    {
        ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool Add(Customer entity)
        {
            if(entity.Name == null || entity.Name == "")
            {
                return false;
            }
            return _customerRepository.Add(entity);
        }
        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
        public bool Remove(Customer customer)
        {
            return _customerRepository.Remove(customer);
        }
        public ICollection<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int? id)
        {
            return _customerRepository.GetById(id);
        }
    }
}
