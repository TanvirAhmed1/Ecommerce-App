using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        NewEcommerceDbContext db;
        public ProductRepository(DbContext _db) : base(_db)
        {
            db = (NewEcommerceDbContext)_db;
        }

        public override ICollection<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c => c.Id == id);
        }
    }
}
