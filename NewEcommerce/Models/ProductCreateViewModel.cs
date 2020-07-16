using Ecommerce.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerce.Models
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Price { get; set; }
        public int? CatagoryId { get; set; }
        public int Quantity { get; set; }
        public ICollection<ProductResponseModel> CustomerList { get; set; }
        public ICollection<SelectListItem> CatagoryItems { get; set; }
    }
}
