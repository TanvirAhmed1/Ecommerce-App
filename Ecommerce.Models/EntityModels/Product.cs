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
        public int Quantity { get; set; }
        public Catagory Catagory { get; set; }
    }
}
