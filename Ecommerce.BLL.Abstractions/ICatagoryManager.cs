using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions
{
    public interface ICatagoryManager
    {
        public ICollection<Catagory> GetAll();
    }
}
