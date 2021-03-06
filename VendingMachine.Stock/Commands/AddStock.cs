namespace VendingMachine.Stock.Commands
{
    public class AddStock 
    {
        public AddStock(string flavour, int quantity, decimal price)
        {
            Flavour = flavour;
            Price = price;
            Quantity = quantity;
        }

        /// <summary>
        /// Id and flavour of a can
        /// </summary>
        public string Flavour { get; }
        public int Quantity { get; set; }
        public decimal Price { get; }
    }
}