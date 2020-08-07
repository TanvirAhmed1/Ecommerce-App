using Ecommerce.BLL.Abstractions.Base;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions
{
    public interface IProductManager : IManager<Product>
    {
        Product GetById(int? id);
    }
}
