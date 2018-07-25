using Ximo.Cqrs;

namespace VendingMachine.Payment.Commands
{
    internal class CreditCardPaymentHandler : ICommandHandler<CreditCardPayment>
    {
        private readonly IPaymentAccessLayer _dataAccessLayer;

        public CreditCardPaymentHandler(IPaymentAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void Handle(CreditCardPayment pay)
        {
            _dataAccessLayer.AddCreditPayment(pay.AmountToPay);
        }
    }
}