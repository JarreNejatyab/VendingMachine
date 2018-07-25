namespace VendingMachine.Stock.Queries
{
    public class GetPriceByFlavour
    {
        public string Flavour { get; }

        public GetPriceByFlavour(string flavour)
        {
            Flavour = flavour;
        }
    }
}