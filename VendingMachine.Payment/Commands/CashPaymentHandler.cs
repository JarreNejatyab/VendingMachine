using Ximo.Cqrs;

namespace VendingMachine.Payment.Commands
{
    internal class CashPaymentHandler : ICommandHandler<CashPayment>
    {
        private readonly IPaymentAccessLayer _dataAccessLayer;

        public CashPaymentHandler(IPaymentAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void Handle(CashPayment pay)
        {
            _dataAccessLayer.AddCashPayment(pay.AmountToPay);
        }
    }
}