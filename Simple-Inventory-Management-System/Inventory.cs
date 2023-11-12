using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
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

        public void save(Product product)
        {
            if (product != null)
            {
                inventory.Add(product);
            }
            else
            {
                throw new NullReferenceException("Failed to add the product !");
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
    }
}
