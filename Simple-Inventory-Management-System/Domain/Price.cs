namespace Simple_Inventory_Management_System.ProductManagement
{
    public class Price
    {
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value), "Invalid amount !");
                }

                _amount = value;
            }
        }

        public Currency Currency { get; set; }

        public Price(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        private char CurrencySign()
        {
            return Currency switch
            {
                Currency.Dollar => '$',
                Currency.Euro => '€',
                Currency.Pound => '£',
                _ => throw new NotImplementedException()
            };
        }

        public override string ToString() => $"{Amount} {CurrencySign()}";
    }
}
