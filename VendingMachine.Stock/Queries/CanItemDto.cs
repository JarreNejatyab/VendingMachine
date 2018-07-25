namespace VendingMachine.Stock
{
    public class CanItemDto
    {
        public CanItemDto(string flavour, int quantity, decimal price)
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