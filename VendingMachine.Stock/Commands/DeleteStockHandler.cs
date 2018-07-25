using System.Linq;
using Ximo.Cqrs;

namespace VendingMachine.Stock.Commands
{
    internal class DeleteStockHandler : ICommandHandler<DeleteStock>
    {
        private readonly IVendingDataAccessLayer _dataAccessLayer;

        public DeleteStockHandler(IVendingDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void Handle(DeleteStock can)
        {
            var found = _dataAccessLayer.GetAll().FirstOrDefault(item => item.Flavour == can.Flavour);

            if (found == null)
                return;

            _dataAccessLayer.Delete(can.Flavour);
        }
    }
}