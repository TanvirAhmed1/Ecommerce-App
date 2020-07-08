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
    public class CatagoryRepository : Repository<Catagory>, ICatagoryRepository
    {
        NewEcommerceDbContext _db;
        public CatagoryRepository(DbContext db) : base(db)
        {
            _db = (NewEcommerceDbContext)db;
        }
    }
}
