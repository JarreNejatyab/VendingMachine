using System.Linq;
using Ximo.Cqrs;

namespace VendingMachine.Stock.Commands
{
    internal class EjectCanHandler : ICommandHandler<EjectCan>
    {
        private readonly IVendingDataAccessLayer _dataAccessLayer;

        public EjectCanHandler(IVendingDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void Handle(EjectCan can)
        {
            var found = _dataAccessLayer.GetAll().FirstOrDefault(item => item.Flavour == can.Flavour);

            if (found != null)
                _dataAccessLayer.AddorUpdate(new CanItem(found.Flavour, found.Quantity - 1, found.Price));
        }
    }
}