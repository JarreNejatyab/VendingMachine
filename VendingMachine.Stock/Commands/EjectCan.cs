namespace VendingMachine.Stock.Commands
{
    public class EjectCan
    {
        public string Flavour { get; }

        public EjectCan(string flavour)
        {
            Flavour = flavour;
        }
    }
}