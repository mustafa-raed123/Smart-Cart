using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart.Classes
{
    internal class GroceryStore : ShoppingCart
    {

        
            public  List<Product> StartShopInGroceryStore() => StartShop((ProductCategory.Food));
       
        }
 }

