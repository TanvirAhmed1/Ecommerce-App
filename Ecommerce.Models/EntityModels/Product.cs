using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int? CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}
