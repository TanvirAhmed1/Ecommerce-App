using Ecommerce.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.EntityModels
{
    public class Customer : IDeletable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public ICollection<Customer> CustomerList { get; set; }
        public bool Delete()
        {
            IsDeleted = true;
            return true;
        }
    }
}
