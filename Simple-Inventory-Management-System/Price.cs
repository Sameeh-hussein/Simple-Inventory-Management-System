namespace Simple_Inventory_Management_System
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
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}
