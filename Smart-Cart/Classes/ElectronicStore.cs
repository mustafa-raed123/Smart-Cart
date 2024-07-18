using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
 
namespace Smart_Cart.Classes
{
    internal class ElectronicStore : Shop

    {
        List<Product> ElectronicItems;
        public override void DisplayPruduct()
        {
            ElectronicItems = ProductGenerator.Products(ProductCategory.Electronics); // // To get 30 Elecronic item randomly 


            for (int i = 0; i < ElectronicItems.Count; i++)
            {
                Console.Write($"    {i + 1}-{ElectronicItems[i].Name} : ${ElectronicItems[i].Price}\t\t");
                if ((i + 1) % 3 == 0) Console.WriteLine("\n");
            }
            Console.WriteLine();
        }

        public override Product SelectedPruduct(ShoppingCart cart)
        {
            Console.WriteLine("Enter Enter product number to add to cart, or 0 to go back:");
            bool IsCurrect = int.TryParse(Console.ReadLine(), out int choice);
            while (true)
            {
                if (IsCurrect)
                {
                    if (choice > 0 && choice <= ElectronicItems.Count)
                    {
                        Product product = ElectronicItems[choice - 1];
                        Console.WriteLine(product.Name);
                        return product;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    Console.WriteLine("PLease Enter the Number");
                    continue;
                }
            }
            return null;


        }

    }
}
