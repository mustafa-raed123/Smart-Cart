using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace Smart_Cart.Classes
{
    public class ProductGenerator
    {
        public static List<Product> Products(ProductCategory category)
        {
            List<Product> product = GenerateProduct(category);
            Random random = new Random();
            List<Product> randomProducts = product.OrderBy(x => random.Next()).Take(30).ToList();
            return randomProducts;
        }
  

        public static List<Product> GenerateProduct(ProductCategory category)
        {
            Dictionary<string, Dictionary<string, decimal>> itemsWithPrices = GetProductFromJson();
            List<Product> ProductList = new List<Product>();

            if (itemsWithPrices != null && itemsWithPrices.ContainsKey(category.ToString()))
            {
                Dictionary<string, decimal> Items = itemsWithPrices[category.ToString()];

                foreach (var item in Items)
                {
                    Product product = new Product(item.Key, item.Value , category );
                    ProductList.Add(product);
                    product.Category = category;
                   
                }
            }
            return ProductList;
        }
        public static Dictionary<string, Dictionary<string, decimal>> GetProductFromJson()
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "jsconfig1.json");
            var ProductList = new List<Product>();
            Dictionary<string, Dictionary<string, decimal>> itemsWithPrices = new Dictionary<string, Dictionary<string, decimal>>();
            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);

                itemsWithPrices = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, decimal>>>(jsonString);

            }
            else
            {
                Console.WriteLine($"File not found: {jsonFilePath}");
            }
            return itemsWithPrices;
        }

    
    }
}

