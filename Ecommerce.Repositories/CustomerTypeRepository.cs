using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories
{
    public class CustomerTypeRepository:Repository<CustomerType>, ICustomerTypeRepository
    {
        NewEcommerceDbContext _db;
        public CustomerTypeRepository(DbContext db):base(db)
        {
            _db = (NewEcommerceDbContext)db;
        }
    }
}
