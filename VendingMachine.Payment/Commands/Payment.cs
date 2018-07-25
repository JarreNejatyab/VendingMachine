namespace VendingMachine.Payment.Commands
{
    public abstract class Payment
    {
        public decimal AmountToPay { get; }

        protected Payment(decimal amountToPay)
        {
            AmountToPay = amountToPay;
        }
    }
}