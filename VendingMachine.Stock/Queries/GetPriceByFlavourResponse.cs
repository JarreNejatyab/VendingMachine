namespace VendingMachine.Stock.Queries
{
    public class GetPriceByFlavourResponse
    {
        public decimal? Price { get; }

        private GetPriceByFlavourResponse()
        {
        }

        public GetPriceByFlavourResponse(decimal? price)
            : this()
        {
            Price = price;
        }
    }
}