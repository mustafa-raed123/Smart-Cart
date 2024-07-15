using Smart_Cart.Classes;

namespace Smart_Cart
{
    public class Program
    {
        static void Main(string[] args)
        {
          List<Product> allItemsThatSelected = new List<Product>();
            Console.WriteLine("Welcome to Online Store ");
            while (true)
            {
                Console.WriteLine("What Do  You need: ");
                Console.WriteLine("1- Add to cart");
                Console.WriteLine("2- view Cart");
                Console.WriteLine("3- Remove Items");
                Console.WriteLine("4- ShowTHeBill");
                Console.WriteLine("5- Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddProducts(ref allItemsThatSelected);
                        break;
                    case "2":
                        ViewAllItemsInTHeCart(allItemsThatSelected);
                        break;
                    case "3":
                        allItemsThatSelected.Remove(allItemsThatSelected[RemoveItems(allItemsThatSelected)]);
                        break;
                    case "4":
                        ShowTHeBill(allItemsThatSelected);
                        break;
                    case "5":
                        return;
                }

            }
        }
        private static void AddProducts(ref List<Product> allItemsThatSelected)
        {
            List<Product> SubSelected = new List<Product>();
            Console.WriteLine("What store do you want to buy?");
            ProductCategory[] categories = (ProductCategory[])Enum.GetValues(typeof(ProductCategory));
            int count = 0;
            foreach (ProductCategory category in categories)
            {
                Console.WriteLine($"{count + 1}-{category}");
                count++;
            }

            switch (Console.ReadLine())
            {
                case "1":
                    GroceryStore groceryStore = new GroceryStore();
                    SubSelected = groceryStore.StartShopInGroceryStore();
                    break;
                case "2":
                    ClothingStore clothingStore = new ClothingStore();
                    SubSelected = clothingStore.StartShopInClothingStore();
                    break;
                case "3":
                    ElectronicStore electronic = new ElectronicStore(); 
                    SubSelected = electronic.StartShopInElectronicStore();
                    break;
                default:
                    Console.WriteLine("Incurrect : Try again");
                    return;

            }
            AddSubItemToAllItems(SubSelected , ref allItemsThatSelected);


        }
        private static void AddSubItemToAllItems(List<Product> SubSelected , ref List<Product> allItemsThatSelected)
        {

            foreach (Product Product in SubSelected)
            {
                allItemsThatSelected.Add(Product);

            }

        }
        private static void ViewAllItemsInTHeCart(List<Product> allItemsThatSelected)
        {
            foreach (Product Product in allItemsThatSelected)
            {
                Console.WriteLine();

                Console.WriteLine($"{Product.Name}        {Product.Price}             ├ {Product.Category} ");
            }
            Console.WriteLine();
        }
        public static int RemoveItems(List<Product> selected)
        {
            int count = 0;
            Console.WriteLine("What items do you want to remove?");
            foreach (var product in selected)
            {
                count++;
                Console.Write($"    {count}-{product.Name} : ${product.Price}  ├{product.Category}\t\t");

                // After printing 3 products, start a new line
                if (count % 3 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            while (true)
            {
                var ReadInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ReadInput) && int.TryParse(ReadInput, out int Input))
                {
                    if (Input <= selected.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Removing Successfully");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return Input - 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number less than or equal to the available items.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input : Please Try again");
                }
            }
        }
        public static decimal CalculateTHePrice(List<Product> allItemsThatSelected)
        {
            decimal price = 0;
            foreach (var item in allItemsThatSelected)
            {
                price += item.Price;
            }
            return price;
        }
        private static void ShowTHeBill(List<Product> allItemsThatSelected)
        {
            int count = 1;
            foreach (var item in allItemsThatSelected)
            {
                Console.WriteLine($"\t\t{count++}├ {item.Name} \t\t\t  {item.Price}   ");

            }
            Console.WriteLine();
            Console.WriteLine($"\t\t    Total Price  \t\t  [{CalculateTHePrice(allItemsThatSelected)}]");
        }
    }
}
