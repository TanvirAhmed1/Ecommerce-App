using Ecommerce.BLL.Abstractions;
using Ecommerce.BLL.Abstractions.Base;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetById(int? id)
        {
            if (id != null)
            {
                return _productRepository.GetById(id);
            }
            return null;
        }
    }
}
