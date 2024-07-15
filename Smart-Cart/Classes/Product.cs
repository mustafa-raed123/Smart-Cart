using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart.Classes
{
    public enum ProductCategory {
        Food,
        Clothing,
        Electronics
    }

    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public Product(string Name, decimal Price , ProductCategory category)
        {
            this.Name = Name;
            this.Price = Price;
            this.Category = Category;
        }
    }

         
       
    
}
    
