using Simple_Inventory_Management_System;
using System.ComponentModel.DataAnnotations;

namespace SIMS.Test
{
    public class UnitTest1
    {
        private readonly Inventory inventory;

        public UnitTest1()
        {
            inventory = new Inventory();
        }

        [Fact]
        public void SaveMethod_Should_ReturnTrue_When_AddAProduct()
        {
            var prod = new Product("Egg", 10.5, 30);

            var result = inventory.Save(prod);

            Assert.True(result);
            Assert.Contains(prod, inventory.Cast<Product>());
        }

        [Fact]
        public void SaveMethod_Should_ThrowExeption_When_PassNullProduct()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => inventory.Save(null));
            Assert.Equal("Product cannot be null for addition! (Parameter 'product')", ex.Message);
        }

        [Fact]
        public void DeleteMethod_Should_ReturnTrue_When_RemoveAProduct()
        {
            var prod = new Product("Egg", 10.5, 30);

            inventory.Save(prod);
            var result = inventory.DeleteProduct(prod);

            Assert.True(result);
            Assert.DoesNotContain(prod, inventory.Cast<Product>());
        }

        [Fact]
        public void DeleteMethod_Should_ThrowException_When_PassNullProduct()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => inventory.DeleteProduct(null));
            Assert.Equal("Product cannot be null for deletion! (Parameter 'product')", ex.Message);
        }

        [Theory]
        [InlineData("Egg", 10.5, 30)]
        [InlineData("Milk", 5, 10)]
        [InlineData("tomato", 9.9, 40)]
        public void FindProductMethod_Should_ReturnProduct_WhenFindIt(string name, double price, int quantity)
        {
            var prod = new Product(name, price, quantity);

            inventory.Save(prod);
            var temp = inventory.FindProduct(name);

            Assert.NotNull(temp);
            Assert.Equal(name, temp.Name);
            Assert.Equal(price, temp.Price);
            Assert.Equal(quantity, temp.Quantity);
        }

        [Fact]
        public void ExistMethodShould()
        {
            var prod = new Product("Egg", 10.5, 30);

            inventory.Save(prod);

            Assert.True(inventory.Exist("Egg"));
        }

        [Fact]
        public void GetAllMethod_Should_ReturnAllProduct_When_CallIt()
        {
            var prod1 = new Product("Egg", 10.5, 30);
            var prod2 = new Product("Milk", 9.9, 5);

            inventory.Save(prod1);
            inventory.Save(prod2);

            var result = inventory.GetAll();

            Assert.NotNull(result); 
            Assert.Equal(2, result.Count); 
            Assert.Contains(prod1, result); 
            Assert.Contains(prod2, result); 
        }
    }
}