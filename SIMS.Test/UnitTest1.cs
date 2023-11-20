using SimpleInventoryManagementSystem;
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

            inventory.save(prod);

            var result = inventory.save(prod);

            Assert.True(result);
            Assert.Contains(prod, inventory.Cast<Product>());
        }

        [Fact]
        public void SaveMethod_Should_ThrowExeption_When_PassNullProduct()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => inventory.save(null));
            Assert.Equal("Product cannot be null for addition!", ex.Message);
        }

        [Fact]
        public void DeleteMethod_Should_ReturnTrue_When_RemoveAProduct()
        {
            var prod = new Product("Egg", 10.5, 30);

            inventory.save(prod);
            var result = inventory.DeleteProduct(prod);

            Assert.True(result);
            Assert.DoesNotContain(prod, inventory.Cast<Product>());
        }

        [Fact]
        public void DeleteMehtod_Should_ThrowExeption_When_PassNullProduct()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => inventory.DeleteProduct(null));
            Assert.Equal("Product cannot be null for deletion!", ex.Message);
        }

        [Fact]
        public void FindProductMethodShould()
        {
            var prod = new Product("Egg", 10.5, 30);

            inventory.save(prod);
            var temp = inventory.findProduct("Egg");

            Assert.NotNull(temp);
            Assert.Equal("Egg", temp.name);
            Assert.Equal(10.5, temp.price);
            Assert.Equal(30, temp.quantity);
        }

        [Fact]
        public void ExistMethodShould()
        {
            var prod = new Product("Egg", 10.5, 30);

            inventory.save(prod);

            Assert.True(inventory.Exist("Egg"));
        }
    }
}