using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : BaseEntity
    {
        public Product()
        {

        }

        public Product(int id, string name, string code, decimal price)
        {
            Id = id;
            Name = name;
            Code = code;
            Price = price;
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
