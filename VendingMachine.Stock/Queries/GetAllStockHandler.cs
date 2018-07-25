using System.Linq;
using Ximo.Cqrs;

namespace VendingMachine.Stock.Queries
{
    internal class GetAllStockHandler :
        IQueryHandler<GetAllStock, GetAllStockResponse>
    {
        private readonly IVendingDataAccessLayer _dataAccessLayer;

        public GetAllStockHandler(IVendingDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public GetAllStockResponse Read(GetAllStock query)
        {
            return new GetAllStockResponse(_dataAccessLayer.GetAll().OrderBy(item => item.Flavour));
        }
    }
}