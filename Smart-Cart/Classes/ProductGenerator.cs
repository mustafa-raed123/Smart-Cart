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
        //public ProductCategory GetCategory(ProductCategory[] productCategories)
        //{
        //    Random rnd = new Random();


        //    return (ProductCategory)productCategories.GetValue(rnd.Next(0, 3));
        //}
        //public static string GetName(ProductCategory category,List<string> names)
        //{
        //    Random random = new Random();
        //    if (category.ToString() == "Food")
        //    {
        //        List<string> FoodList = new List<string>()
        //        {
        //            "Apple", "Banana", "Orange", "Grapes", "Strawberry", "Blueberry", "Mango", "Pineapple", "Watermelon", "Kiwi",
        //            "Tomato", "Cucumber", "Carrot", "Broccoli", "Spinach", "Potato", "Pumpkin", "Peas", "Bell Pepper",
        //            "Onion", "Garlic", "Ginger", "Lettuce", "Cabbage", "Cauliflower", "Mushroom", "Zucchini", "Eggplant", "Corn" ,"Papaya", 
        //             "Avocado", "Peach", "Pear", "Plum", "Cherry", "Apricot", "Fig", "Date",
        //            "Raspberry", "Blackberry", "Coconut", "Pomegranate", "Celery", "Radish",
        //        };
        //        while (true)
        //        {
        //            string name = FoodList[random.Next(0, FoodList.Count)];
        //            if (!CheckContains(name, names))
        //            {
        //              return name;

        //            }
        //        }
        //    }
        //    else if (category.ToString() == "Clothing")
        //    {
        //        List<string> ClothingList = new List<string>() {
        //              "T-shirt", "Jeans", "Jacket", "Sweater", "Hoodie", "Blazer", "Dress", "Skirt", "Shorts", "Pants",
        //              "Suit", "Coat", "Scarf", "Hat", "Gloves", "Socks", "Shoes", "Sandals", "Boots", "Sneakers",
        //              "Belt", "Tie", "Blouse", "Cardigan", "Vest", "Polo Shirt", "Tank Top", "Leggings", "Overalls", "Swimsuit",
        //              "Sweatshirt", "Parka", "Jumpsuit", "Kimono", "Tuxedo", "Peacoat", "Anorak", "Windbreaker", "Chinos", "Raincoat",
        //               "Poncho", "Fleece", "Culottes", "Bomber Jacket", "Fedora", "Beanie", "Flip-flops", "Espadrilles", "Loafers", "Slippers",
        //               "Wetsuit", "Bow Tie", "Waistcoat", "Sarong", "Harem Pants", "Turtleneck", "Pajamas", "Swim Trunks", "Apron", "Uniform"
        //        };

        //        while (true)
        //        {
        //            string name = ClothingList[random.Next(0, ClothingList.Count)];
        //            if (!CheckContains(name , names))
        //            {
        //            return name;                       
        //            }
        //        }
        //    }
        //    else
        //    {
        //        List<string> ElectronicsList = new List<string>() {
        //              "Smartphone", "Laptop", "Tablet", "Desktop PC", "Smartwatch", "Television", "Gaming Console", "Camera", "Printer", "Monitor",
        //              "Keyboard", "Mouse", "Headphones", "Bluetooth Speaker", "Router", "Smart Home Hub", "Drone", "E-reader", "Fitness Tracker", "VR Headset",
        //              "Portable Charger", "External Hard Drive", "Smart Light Bulb", "Smart Thermostat", "Electric Toothbrush", "Electric Shaver",
        //              "Microwave", "Blender", "Coffee Maker", "Refrigerator","Projector", "Action Camera", "Wireless Earbuds", "Gaming Mouse", "Graphics Tablet", "External SSD", "Smart Scale",
        //              "Robot Vacuum", "Electric Scooter", "Digital Camera", "Smart Lock", "Portable Projector", "Mini PC", "Desk Lamp",
        //              "Voice Assistant", "Electric Toothbrush", "Fitness Band", "Smart Mirror",
        //        };
        //        while (true)
        //        {
        //            string name = ElectronicsList[random.Next(0, ElectronicsList.Count)];
        //            if (!CheckContains(name, names))
        //            {
        //            return name;                        
        //            }
        //        }
        //    }
        //}
        //public static decimal GetPrice()
        //{
        //    Random rnd = new Random();
        //    return (decimal)(rnd.Next(50, 250) * 1.86);
        //}
        //public static bool CheckContains(string name, List<string> namesOfProducts)
        //{
        //   return  namesOfProducts.Contains(name);
        //}

        public static List<Product> GenerateProduct(ProductCategory category)
        {
            Dictionary<string, Dictionary<string, decimal>> itemsWithPrices = GetProductFromJson();
            List<Product> ProductList = new List<Product>();

            if (itemsWithPrices != null && itemsWithPrices.ContainsKey(category.ToString()))
            {
                Dictionary<string, decimal> Items = itemsWithPrices[category.ToString()];

                foreach (var item in Items)
                {
                    Product v = new Product(item.Key, item.Value , category );
                    ProductList.Add(v);
                    v.Category = category;
                   
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

