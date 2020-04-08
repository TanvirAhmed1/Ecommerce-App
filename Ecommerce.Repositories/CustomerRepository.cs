using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Ecommerce.Repositories.Abstractions;

namespace Ecommerce.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        NewEcommerceDbContext db; 
        public CustomerRepository(DbContext dbContext)
        {
            db = (NewEcommerceDbContext)dbContext;
        }
        public bool Add(Customer entity)
        {
            db.Customers.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Customer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() >0;
        }
        public ICollection<Customer> GetAll()
        {
            return db.Customers.Where(c => c.IsDeleted == false).ToList();
        }
        public bool Remove(Customer customer)
        {
            customer.IsDeleted = true;
            return Update(customer);
        }

        public Customer GetById(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return db.Customers.Find(id);
        }
    }
}
