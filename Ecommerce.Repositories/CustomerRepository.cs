using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Ecommerce.Models.RequestModels;

namespace Ecommerce.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        NewEcommerceDbContext db;
        public CustomerRepository(DbContext _db) : base(_db)
        {
            db = (NewEcommerceDbContext)_db;
        }



        public override ICollection<Customer> GetAll()
        {
            return db.Customers.Where(c => c.IsDeleted == false).ToList();
        }



        public Customer GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c => c.Id == id);
        }

        public ICollection<Customer> GetByRequest(CustomerRequestModel customer)
        {
            var result = db.Customers.AsQueryable();
            if (customer == null)
            {
                return result.ToList();
            }
            if (customer.Id > 0)
            {
                result = result.Where(c => c.Id == customer.Id);
            }
            if (!string.IsNullOrEmpty(customer.Name))
            {
                result = result.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(customer.Address))
            {
                result = result.Where(c => c.Address.ToLower().Contains(customer.Address.ToLower()));
            }
            if (!string.IsNullOrEmpty(customer.PhoneNo))
            {
                result = result.Where(c => c.PhoneNo.ToLower().Equals(customer.PhoneNo.ToLower()));
            }
            if (customer.IsDeleted != null)
            {
                result = result.Where(c => c.IsDeleted == customer.IsDeleted);
            }
            return result.ToList();
        }
    }
}
