using Ecommerce.BLL.Abstractions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class CatagoryManager : ICatagoryManager
    {
        ICatagoryRepository _catagoryRepository;
        public CatagoryManager(ICatagoryRepository catagoryRepo)
        {
            _catagoryRepository = catagoryRepo;
        }
        public ICollection<Catagory> GetAll()
        {
            return _catagoryRepository.GetAll();
        }
    }
}
