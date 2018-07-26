namespace VendingMachine.Payment.Commands
{
    public class CashPayment : Commands.Payment
    {
        public CashPayment(decimal amountToPay) : base(amountToPay)
        {
        }
    }
}