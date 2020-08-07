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
    public class CategoryRepository : Repository<Catagory>, ICatagoryRepository
    {
        NewEcommerceDbContext db;
        public CategoryRepository(DbContext _db) : base(_db)
        {
            db = (NewEcommerceDbContext)_db;
        }


        public Catagory GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c => c.Id == id);
        }
    }
}
