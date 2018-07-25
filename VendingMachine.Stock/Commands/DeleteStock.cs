namespace VendingMachine.Stock.Commands
{
    public class DeleteStock
    {
        public string Flavour { get; }

        public DeleteStock(string flavour)
        {
            Flavour = flavour;
        }
    }
}