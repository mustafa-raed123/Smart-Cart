using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart.Classes
{
    public class ShoppingCart
    {
       
      //  List<Product> allItemsThatSelected = new List<Product>();

        public List<Product> ShopingCart;
        public ShoppingCart()
        {
            ShopingCart = new List<Product>();
           

        }
            public void AddItemToCart(Product product)
            {
                    ShopingCart.Add(product);
            }
  
        public  void ViewCart()
            {
            int count = 1;
            foreach (var item in ShopingCart)
            {
                Console.WriteLine($"\t\t{count++}├ {item.Name} \t\t\t  {item.Price}   ");

            }
            Console.WriteLine();
          
        }

        public void RemoveItems()
            {
            if (ShopingCart.Count() == 0) {

                Console.WriteLine("THe Cart IS Empty");
                Console.WriteLine();
                return;
            }
                ViewCart();
                Console.WriteLine("Which item do you want to remove? Enter A Number Items ,  or 0 to go back: ");
          
                while (true)
                {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice > 0 && choice <= ShopingCart.Count())
                        RemoveItemFromCart(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input.Please Enter A Number ");
                    continue;
                }
                    return;

                    }
                }
        public void RemoveItemFromCart(int choice )
        {
            ShopingCart.RemoveAt(choice - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Removed successfully");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        public decimal CalculateTotalCost()
        {
            decimal TotalCost = 0;
            foreach (var item in ShopingCart)
            {
                TotalCost += item.Price;
            }
            ViewCart();
            return TotalCost;
        }


    }

        
}     

