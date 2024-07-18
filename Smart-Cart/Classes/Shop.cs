using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart.Classes
{
    internal abstract class Shop
    {
        public  abstract void DisplayPruduct();
        public abstract Product SelectedPruduct( ShoppingCart cart  );



    }
}
