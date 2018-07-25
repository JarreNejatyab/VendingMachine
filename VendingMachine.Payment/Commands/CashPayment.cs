namespace VendingMachine.Payment
{
    public class CashPayment : Commands.Payment
    {
        public CashPayment(decimal amountToPay) : base(amountToPay)
        {
        }
    }
}