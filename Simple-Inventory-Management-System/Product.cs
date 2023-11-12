using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    public class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public long quantity { get; set; }

        public Product(string name, double price, long quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString() => $"Name: {this.name}, Price: {this.price}, Quantity: {this.quantity}";
    }
}
