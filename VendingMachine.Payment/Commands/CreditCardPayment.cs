namespace VendingMachine.Payment.Commands
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(decimal amountToPay) : base(amountToPay)
        {
        }
    }
}