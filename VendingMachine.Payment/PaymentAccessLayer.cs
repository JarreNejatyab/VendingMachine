namespace VendingMachine.Payment
{
    internal class PaymentAccessLayer : IPaymentAccessLayer
    {
        private decimal _creditBalance;
        private decimal _cashBalance;

        public void AddCreditPayment(decimal pay)
        {
            _creditBalance += pay;
        }

        public void AddCashPayment(decimal pay)
        {
            _cashBalance += pay;
        }

        public void ResetBalance()
        {
            _cashBalance = 0;
            _creditBalance = 0;
        }

        public decimal GetCashBalance()
        {
            return _cashBalance;
        }

        public decimal GetCreditBalance()
        {
            return _creditBalance;
        }
    }
}