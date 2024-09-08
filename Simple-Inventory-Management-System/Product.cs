namespace Simple_Inventory_Management_System
{
    public class Product
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

        private char CurrencySign()
        {
            return Price.Currency switch
            {
                Currency.Dollar => '$',
                Currency.Euro => '€',
                Currency.Pound => '£',
                _ => throw new NotImplementedException()
            };
        }

        public override string ToString() =>
            $"Product Id: {Id}, Name: {Name}, Price: {Price.Amount} {CurrencySign()}, Quantity: {Quantity}";
    }
}
