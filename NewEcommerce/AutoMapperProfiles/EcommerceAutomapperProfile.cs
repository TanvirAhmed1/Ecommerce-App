using AutoMapper;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ResponseModels;
using NewEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerce.AutoMapperProfiles
{
    public class EcommerceAutomapperProfile:Profile
    {
        public EcommerceAutomapperProfile()
        {
            CreateMap<CustomerCreateViewModel, Customer>();
            CreateMap<Customer, CustomerCreateViewModel>();
            CreateMap<Customer, CustomerResponseModel>();
            CreateMap<Customer, CustomerEditViewModel>();
            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<Product, ProductCreateViewModel>();
            CreateMap<Product, ProductResponseModel>();
            CreateMap<Product, ProductEditViewModel>();
        }
    }
}
