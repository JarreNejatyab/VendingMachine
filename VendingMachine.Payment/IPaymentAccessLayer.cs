using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Payment.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

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