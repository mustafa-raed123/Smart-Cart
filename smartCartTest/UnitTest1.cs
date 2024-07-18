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
            List<Product> ChoppingCart = cart.ShopingCart;

            // Act
            cart.AddItemToCart(products[0]);
            cart.AddItemToCart(products[1]);
            cart.AddItemToCart(products[2]);
            Product productOne = ChoppingCart[0];

            // Assert
            
            Assert.Equal("Orange", productOne.Name);
            Assert.Equal(3.4m, productOne.Price);

            // Act
            cart.RemoveItemFromCart(1);  /// remove first product from ShoppingCart
            productOne = ChoppingCart[0];
            //// Assert
            Assert.Equal("Banana", productOne.Name);
            Assert.Equal(3.4m, productOne.Price);
        }

        [Fact]
        public void Price()
        {
            ShoppingCart cart = new ShoppingCart();
            var Products = new List<Product> {
                  new Product("Orange" , 3m,ProductCategory.Food),
                  new Product("Running Shoes" , 22m,ProductCategory.Clothing),
                  new Product("Electric Shaver" , 222m,ProductCategory.Electronics),
                  new Product("Banana" , 3.4m,ProductCategory.Food)
                };
            cart.AddItemToCart(Products[0]);
            cart.AddItemToCart(Products[1]);
            cart.AddItemToCart(Products[2]);
            cart.AddItemToCart(Products[3]);
            //Act
            decimal Cost =  cart.CalculateTotalCost();
            // Assert  
            Assert.Equal(Cost, 250.4m);

        }
    }
}
