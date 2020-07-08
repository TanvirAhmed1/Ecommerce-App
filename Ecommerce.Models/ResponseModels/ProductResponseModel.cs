using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Models.ResponseModels
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Price { get; set; }
    }
}
