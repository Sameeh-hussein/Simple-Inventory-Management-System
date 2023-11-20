using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem
{
    public class Inventory : IEnumerable
    {
        private List<Product> inventory;

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

        public bool save(Product? product)
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
            return inventory.Any(it => it.name == name);
        }

        public Product findProduct(string name)
        {
            return inventory.First(it => it.name == name);
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
    }
}