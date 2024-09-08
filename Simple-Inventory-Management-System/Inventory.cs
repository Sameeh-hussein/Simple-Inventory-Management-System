using System.Collections;

namespace Simple_Inventory_Management_System
{
    public class Inventory : IEnumerable
    {
        private readonly List<Product> inventory;

        public Inventory()
        {
            inventory = new List<Product>();
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
                inventory.Add(product);
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null for addition!");
            }
        }

        public bool Exist(string name)
        {
            return inventory.Any(it => it.Name.Equals(name));
        }

        public Product FindProduct(string name)
        {
            return inventory.First(it => it.Name.Equals(name));
        }

        public bool DeleteProduct(Product? product)
        {
            if (product != null)
            {
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