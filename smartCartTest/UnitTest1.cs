using Smart_Cart;
using Smart_Cart.Classes;

namespace smartCartTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddingandRemoving()
        {
            // Arrange
            List<Product> products = new List<Product>
            {
                new Product("Orange", 3.4m, ProductCategory.Food),
                new Product("Banana", 3.4m, ProductCategory.Food),
                new Product("Broccoli", 3.4m, ProductCategory.Food)
            };

            ShoppingCart cart = new ShoppingCart();
            List<Product> selected = new List<Product>();

            // Act
            cart.AddItemToCart(1, products, ref selected);

            // Assert
            Assert.Single(selected);
            Assert.Equal("Orange", selected[0].Name);
            Assert.Equal(3.4m, selected[0].Price);

            // Act
            cart.RemoveItemFromSelected(1, ref selected);

            // Assert
            Assert.Empty(selected);
        }

        [Fact]
        public void Price()
        {
            var allItemsThatSelected = new List<Product> {
              new Product("Orange" , 3m,ProductCategory.Food),
              new Product("Running Shoes" , 22m,ProductCategory.Clothing),
              new Product("Electric Shaver" , 222m,ProductCategory.Electronics),
              new Product("Banana" , 3.4m,ProductCategory.Food)
            };
            //Act
            decimal Price =  Program.CalculateTHePrice(allItemsThatSelected);
            // Assert  
            Assert.Equal(Price , 250.4m);

        }
    }
}
