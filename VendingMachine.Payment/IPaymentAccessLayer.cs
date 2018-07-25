namespace VendingMachine.Payment
{
    internal interface IPaymentAccessLayer
    {
        void AddCreditPayment(decimal pay);
        void AddCashPayment(decimal pay);
        void ResetBalance();
        decimal GetCashBalance();
        decimal GetCreditBalance();
    }
}