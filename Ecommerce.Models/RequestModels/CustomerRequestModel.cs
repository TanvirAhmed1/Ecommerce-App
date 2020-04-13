using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Models.RequestModels
{
    public class CustomerRequestModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
    }
}
