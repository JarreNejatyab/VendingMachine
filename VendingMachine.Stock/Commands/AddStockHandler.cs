using System.Linq;
using Ximo.Cqrs;

namespace VendingMachine.Stock.Commands
{
    internal class AddStockHandler : ICommandHandler<AddStock>
    {
        private readonly IVendingDataAccessLayer _dataAccessLayer;

        public AddStockHandler(IVendingDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void Handle(AddStock can)
        {
            if (_dataAccessLayer.GetAll().ToList().Count == 10)
                return;

            _dataAccessLayer.AddorUpdate(new CanItem(can.Flavour,can.Quantity,can.Price));
        }
    }
}