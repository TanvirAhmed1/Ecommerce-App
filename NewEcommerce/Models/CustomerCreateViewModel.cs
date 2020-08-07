using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewEcommerce.Models
{
    public class CustomerCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<CustomerResponseModel> CustomerList { get; set; }
    }
}
