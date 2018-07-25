using Ximo.Cqrs;

namespace VendingMachine.Payment.Queries
{
    internal class GetBalanceHandler :
        IQueryHandler<GetBalance, GetBalanceResponse>
    {
        private readonly IPaymentAccessLayer _dataAccessLayer;

        public GetBalanceHandler(IPaymentAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public GetBalanceResponse Read(GetBalance query)
        {
            return new GetBalanceResponse(_dataAccessLayer.GetCashBalance(), _dataAccessLayer.GetCreditBalance());
        }
    }
}