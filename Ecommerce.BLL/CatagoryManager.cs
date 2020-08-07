using Ecommerce.BLL.Abstractions;
using Ecommerce.BLL.Abstractions.Base;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class CatagoryManager : Manager<Catagory>, ICatagoryManager
    {
        ICatagoryRepository _catagoryRepository;
        public CatagoryManager(ICatagoryRepository catagoryRepository) : base(catagoryRepository)
        {
            _catagoryRepository = catagoryRepository;
        }

        public Catagory GetById(int? id)
        {
            if (id != null)
            {
                return _catagoryRepository.GetById(id);
            }
            return null;
        }
    }
}
