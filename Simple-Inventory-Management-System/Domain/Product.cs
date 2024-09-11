using Simple_Inventory_Management_System.Contract;

namespace Simple_Inventory_Management_System.ProductManagement
{
    public class Product : ISavable
    {
        private static long IdCounter = 0;
        public long Id { get; private set; }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Product must has a name !");
                }

                _name = value;
            }
        }

        public Price Price { get; set; }

        private long _quantity;
        public long Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(nameof(value), "Invalid quantity !");
                }

                _quantity = value;
            }
        }

        public Product(string name, Price price, long quantity)
        {
            Id = ++IdCounter;
            Name = name;
            Price = price ??
                throw new ArgumentNullException(nameof(price), "Price can't be null");
            Quantity = quantity;
        }

        public Product(Product productToCopy)
        {
            Name = productToCopy.Name;
            Price = new Price(productToCopy.Price.Amount, productToCopy.Price.Currency);
            Quantity = productToCopy.Quantity;
        }

        public override string ToString() => $"Product Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";

        public string ConvertToStringForSaving() => $"{Name};{Price.Amount};{Price.Currency};{Quantity}";
    }
}
