using Microsoft.EntityFrameworkCore;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Database.Database
{
    public class NewEcommerceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = "Server=(local); Database=NewEcommerceDB; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        internal List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

