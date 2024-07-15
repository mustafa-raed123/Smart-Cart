using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
 
namespace Smart_Cart.Classes
{
    public class ElectronicStore :ShoppingCart
    {
        public  List<Product> StartShopInElectronicStore() => StartShop((ProductCategory.Electronics));
      
    }
}
