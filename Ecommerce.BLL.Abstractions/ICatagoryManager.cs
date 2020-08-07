using Ecommerce.BLL.Abstractions.Base;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions
{
    public interface ICatagoryManager : IManager<Catagory>
    {
        Catagory GetById(int? id);
    }
}
