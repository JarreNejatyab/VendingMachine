namespace VendingMachine.Payment.Queries
{
    public class GetBalanceResponse
    {
        private GetBalanceResponse()
        {
        }

        internal GetBalanceResponse(decimal cashBalance, decimal creditBalance)
            : this()
        {
            PaymentBalance = new PaymentBalanceDto(cashBalance,creditBalance);
        }

        public PaymentBalanceDto PaymentBalance { get; }
    }
}