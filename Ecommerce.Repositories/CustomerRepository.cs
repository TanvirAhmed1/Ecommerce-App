using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;

namespace Ecommerce.Repositories
{
    public class CustomerRepository:Repository<Customer>,ICustomerRepository
    {
        NewEcommerceDbContext db; 
        public CustomerRepository(DbContext dbContext): base(dbContext)
        {
            db = (NewEcommerceDbContext)dbContext;
        }
        
        
        public override ICollection<Customer> GetAll()
        {
            return db.Customers
                .Include(c=> c.CustomerType)
                .Where(c => c.IsDeleted == false).ToList();
        }
        

        public Customer GetById(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c=> c.Id == id);
        }
    }
}
