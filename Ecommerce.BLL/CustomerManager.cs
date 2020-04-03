using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    
    public class CustomerManager
    {
        CustomerRepository _customerRepository;
        public CustomerManager()
        {
            _customerRepository = new CustomerRepository();
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
