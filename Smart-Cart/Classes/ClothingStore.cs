using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart.Classes
{
    public class ClothingStore  : ShoppingCart
    {
        public  List<Product> StartShopInClothingStore() => StartShop((ProductCategory.Clothing));


    }
}
