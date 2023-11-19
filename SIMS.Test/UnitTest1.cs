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
        public void SaveMethodShould()
        {
            var prod = new Product("Egg", 10.5, 30);

            inventory.save(prod);

            var temp = inventory.Cast<Product>()
                                .FirstOrDefault(x => x.name.Equals("Egg"));

            Assert.NotNull(temp);
            Assert.Equal("Egg", temp.name);
            Assert.Equal(10.5, temp.price);
            Assert.Equal(30, temp.quantity);

            Assert.Throws<NullReferenceException>(() => inventory.save(null));
        }

        [Fact]
        public void DeleteMethodShould()
        {
            var prod = new Product("Egg", 10.5, 30);

            inventory.save(prod);
            inventory.DeleteProduct(prod);

            var temp = inventory.Cast<Product>()
                                .FirstOrDefault(x => x.name.Equals("Egg"));

            Assert.Null(temp);

            Assert.Throws<NullReferenceException>(() => inventory.DeleteProduct(null));
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