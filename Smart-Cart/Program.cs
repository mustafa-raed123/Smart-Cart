using Smart_Cart.Classes;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Smart_Cart
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            Console.WriteLine("Welcome to Online Store ");
            while (true)
            {
                Console.WriteLine("What Do  You need: ");
                Console.WriteLine("1- Visit Grocery Store");
                Console.WriteLine("2- Visit Clothinf  Store");
                Console.WriteLine("3- Visit Electronic Store");
                Console.WriteLine("4- View Cart");
                Console.WriteLine("5- Remove Item from  Cart");
                Console.WriteLine("6- Calculate Total Cost");
                Console.WriteLine("7- Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        GroceryStore groceryStore = new GroceryStore();
                        groceryStore.DisplayPruduct();
                          Product selectedProductFromGroceryStore  =  groceryStore.SelectedPruduct(cart);
                        if(selectedProductFromGroceryStore != null)
                        {
                            cart.AddItemToCart(selectedProductFromGroceryStore);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Selected: {selectedProductFromGroceryStore.Name} - ${selectedProductFromGroceryStore.Price}");

                            Console.WriteLine("Item added to cart!");
                            Console.ResetColor();
                        }

                        break;
                    case "2":
                        ClothingStore clothingStore = new ClothingStore();
                        clothingStore.DisplayPruduct();
                        Product selectedProductFromClothingStore = clothingStore.SelectedPruduct(cart);
                        if (selectedProductFromClothingStore != null)
                        {
                            cart.AddItemToCart(selectedProductFromClothingStore);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Selected: {selectedProductFromClothingStore.Name} - ${selectedProductFromClothingStore.Price}");
                            Console.WriteLine("Item added to cart!");
                            Console.ResetColor();
                        }
                        break;

                       case "3":
                        ElectronicStore electronicStore = new ElectronicStore();
                        electronicStore.DisplayPruduct();
                        Product selectedProductFromElectronicStore = electronicStore.SelectedPruduct(cart);
                        if (selectedProductFromElectronicStore != null)
                        {
                            cart.AddItemToCart(selectedProductFromElectronicStore);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Selected: {selectedProductFromElectronicStore.Name} - ${selectedProductFromElectronicStore.Price}");
                            Console.WriteLine("Item added to cart!");
                            Console.ResetColor();
                        }
                            break;
                    case "4":
                        cart.ViewCart();
                        break;
                    case "5":
                        cart.RemoveItems();
                        break;
                    case "6":
                         decimal TotalCost =  cart.CalculateTotalCost();
                        Console.WriteLine($"\t\t\tTotal Cost  \t\t[{TotalCost}] ");
                        break;
                    case "7":
                        return;
                }

            }
        }
       
    }
}
