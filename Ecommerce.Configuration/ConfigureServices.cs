using Ecommerce.BLL;
using Ecommerce.BLL.Abstractions;
using Ecommerce.Database.Database;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecommerce.Configuration
{
    public static class ConfigureServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICatagoryRepository, CategoryRepository>();
            services.AddTransient<ICatagoryManager, CatagoryManager>();
            services.AddTransient<DbContext, NewEcommerceDbContext>();
        }
    }
}
