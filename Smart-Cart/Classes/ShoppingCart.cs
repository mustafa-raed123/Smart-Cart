using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart.Classes
{
    public class ShoppingCart
    {
       
        List<Product> allItemsThatSelected = new List<Product>();


        public void startShopping()
        {

            //while (true)
            //{
            //    Console.WriteLine("What Do  You need: ");
            //    Console.WriteLine("1- Add to cart");
            //    Console.WriteLine("2- view Cart");    
            //    Console.WriteLine("3- Remove Items");
            //    Console.WriteLine("4- ShowTHeBill");
            //    Console.WriteLine("5- Exit");
            //    switch (Console.ReadLine())
            //    {
            //        case "1":
            //            AddProducts();
            //            break;
            //        case "2":
            //            ViewAllItemsInTHeCart();
            //            break;
            //        case "3":
            //            allItemsThatSelected.Remove(allItemsThatSelected[RemoveItems(allItemsThatSelected)]);
            //            break;
            //        case "4":
            //            ShowTHeBill();
            //            break;
            //            case "5":
            //            return;
            //    }

        }
        public  List<Product> StartShop(ProductCategory category)
            {
                List<Product> selected = new List<Product>();
                List<Product> products = ProductGenerator.Products(category);
                AddNewItems(products, ref selected);
                while (true)
                {
                    Console.WriteLine("Select");
                    Console.WriteLine("1- Add New Item");
                    Console.WriteLine("2- Remove Item");
                    Console.WriteLine("3- Exit");
                    string input = Console.ReadLine().ToLower();
                switch (input) {
                    case "1":
                        AddNewItems(products, ref selected);
                        break;
                    case "2":
                        RemoveItems(ref selected);
                            break;
                        case "3":
                        return selected;
                }
                }
            }

            public  void AddNewItems(List<Product> products, ref List<Product> selected)
            {
                PrintItems(products);
                Console.WriteLine("Which product do you want to add to cart? Choose the number:");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= products.Count)
                    {
                    //selected.Add(products[choice - 1]);
                    //Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine("Added successfully");
                    AddItemToCart(choice, products,ref selected);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    Console.WriteLine("Invalid input. Please enter a correct number.");
                }
            }
        public  void AddItemToCart(int choice , List<Product> products , ref List<Product> selected)
        {
            selected.Add(products[choice - 1]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Added successfully");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintItems(List<Product> products)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.Write($"    {i + 1}-{products[i].Name} : ${products[i].Price}\t\t");
                    if ((i + 1) % 3 == 0) Console.WriteLine("\n");
                }
            Console.WriteLine();
        }

            public void RemoveItems(ref List<Product> selected)
            {
                Console.WriteLine("Which item do you want to remove?");
                PrintItems(selected);
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= selected.Count)
                    {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("Removed successfully");
                    //Console.ForegroundColor = ConsoleColor.Gray;
                    //return choice - 1;
                    RemoveItemFromSelected( choice,ref  selected );
                    }else
                    Console.WriteLine("Invalid input. ");
                return;
                }
            }
        public void RemoveItemFromSelected(int choice, ref List<Product> selected )
        {
            selected.RemoveAt(choice - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Removed successfully");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        


        }

        //private  void AddProducts()
        //{
        //    List<Product> SubSelected = new List<Product>(); 
        //    Console.WriteLine("What store do you want to buy?");
        //    ProductCategory[] categories = (ProductCategory[])Enum.GetValues(typeof(ProductCategory));
        //    int count = 0;
        //    foreach (ProductCategory category in categories)
        //    {
        //        Console.WriteLine($"{count + 1}-{ category}");
        //        count++;
        //    }

        //    switch (Console.ReadLine()) {
        //        case "1":
        //            SubSelected =  GroceryStore.StartShopInGroceryStore();
        //            break;
        //        case "2":
        //            SubSelected= ClothingStore.StartShopInClothingStore();
        //            break;
        //        case "3":
        //            SubSelected= ElectronicStore.StartShopInElectronicStore();
        //            break;
        //        default:
        //            Console.WriteLine("Incurrect : Try again");
        //            return;

        //    }
        //    AddSubItemToAllItems(SubSelected);
            
            
        //}
        //private  void AddSubItemToAllItems(List<Product> SubSelected ) {

        //    foreach (Product Product in SubSelected)
        //    {
        //        allItemsThatSelected.Add(Product);

        //    }
        
        //}
        //private void ViewAllItemsInTHeCart()
        //{
        //    foreach (Product Product in allItemsThatSelected)
        //    {
        //        Console.WriteLine();
                  
        //        Console.WriteLine($"{Product.Name}        {Product.Price}             ├ {Product.Category} ");
        //    }
        //    Console.WriteLine();
        //}
        //private decimal CalculateTHePrice()
        //{
        //    decimal price = 0;
        //    foreach (var item in allItemsThatSelected)
        //    {
        //        price += item.Price;
        //    }
        //    return price;
        //}
        //private void ShowTHeBill()
        //{
        //    int count = 1;
        //    foreach(var item in allItemsThatSelected)
        //    {
        //        Console.WriteLine($"\t\t {count++}├ {item.Name} \t\t\t  {item.Price}   ");
                
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine($"\t\t    Total Price  \t\t  [{CalculateTHePrice()}]");
        //}



        //public static int RemoveItems(List<Product> selected)
        //{
        //    int count = 0;
        //    Console.WriteLine("What items do you want to remove?");
        //    foreach (var product in selected)
        //    {
        //        count++;
        //        Console.Write($"    {count}-{product.Name} : ${product.Price}\t\t");

        //        // After printing 3 products, start a new line
        //        if (count % 3 == 0)
        //        {
        //            Console.WriteLine();
        //            Console.WriteLine();
        //        }
        //        Console.WriteLine();
        //        Console.WriteLine();
        //    }
        //    while (true)
        //    {
        //        var ReadInput = Console.ReadLine();
        //        if (!string.IsNullOrWhiteSpace(ReadInput) && int.TryParse(ReadInput, out int Input))
        //        {
        //            if (Input <= selected.Count)
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("Removing Successfully");
        //                Console.ForegroundColor = ConsoleColor.Gray;
        //                return Input - 1;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid input. Please enter a number less than or equal to the available items.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid Input : Please Try again");
        //        }
        //    }
        //}
}     

