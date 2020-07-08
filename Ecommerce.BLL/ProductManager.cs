using Ecommerce.BLL.Abstractions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class ProductManager: IProductManager
    {
        IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool Add(Product entity)
        {
            if (entity.Name == null || entity.Name == "")
            {
                return false;
            }
            return _productRepository.Add(entity);
        }
        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }
        public bool Remove(Product product)
        {
            return _productRepository.Remove(product);
        }
        public ICollection<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int? id)
        {
            return _productRepository.GetById(id);
        }
    }
}
