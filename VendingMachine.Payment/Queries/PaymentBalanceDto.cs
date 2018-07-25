namespace VendingMachine.Payment.Queries
{
    public class PaymentBalanceDto
    {
        public decimal CashBalance { get; }
        public decimal CreditBalance { get; }

        public PaymentBalanceDto(decimal cashBalance, decimal creditBalance)
        {
            CashBalance = cashBalance;
            CreditBalance = creditBalance;
        }
    }
}