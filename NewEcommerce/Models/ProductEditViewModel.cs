﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerce.Models
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Price { get; set; }
        public int? CatagoryId { get; set; }
        public ICollection<SelectListItem> CatagoryItems { get; set; }
        public int Quantity { get; set; }
    }
}
