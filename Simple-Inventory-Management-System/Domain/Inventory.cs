using System.Collections;
using Simple_Inventory_Management_System.Data;
using Simple_Inventory_Management_System.ProductManagement;

namespace Simple_Inventory_Management_System.Domain
{
    public class Inventory : IEnumerable
    {
        private readonly List<Product> inventory;
        private readonly ProductRepository repository;

        public Inventory()
        {
            repository = new();
            inventory = repository.LoadProductsFromFile();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in inventory)
            {
                yield return item;
            }
        }

        public bool Save(Product? product)
        {
            if (product != null)
            {
                repository.SaveProductInFile(product);
                inventory.Add(product);
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null for addition!");
            }
        }

        public bool Edit(string name, Product? product)
        {
            if (product != null)
            {
                repository.EditProductInFile(name, product);
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null for editing!");
            }
        }

        public bool Exist(string name)
        {
            return inventory.Any(it => it.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Product FindProduct(string name)
        {
            return inventory.First(it => it.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool DeleteProduct(Product? product)
        {
            if (product != null)
            {
                repository.DeleteProductFromFile(product.Name);
                return inventory.Remove(product);
            }
            else
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null for deletion!");
            }
        }

        public List<Product> GetAll()
        {
            return inventory;
        }
    }
}