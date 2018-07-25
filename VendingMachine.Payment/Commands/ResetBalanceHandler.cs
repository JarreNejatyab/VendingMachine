using Ximo.Cqrs;

namespace VendingMachine.Payment.Commands
{
    internal class ResetBalanceHandler : ICommandHandler<ResetBalance>
    {
        private readonly IPaymentAccessLayer _dataAccessLayer;

        public ResetBalanceHandler(IPaymentAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void Handle(ResetBalance pay)
        {
            _dataAccessLayer.ResetBalance();
        }
    }
}