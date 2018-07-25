using System.Linq;
using Ximo.Cqrs;

namespace VendingMachine.Stock.Queries
{
    internal class GetPriceByFlavourHandler :
        IQueryHandler<GetPriceByFlavour, GetPriceByFlavourResponse>
    {
        private readonly IVendingDataAccessLayer _dataAccessLayer;

        public GetPriceByFlavourHandler(IVendingDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public GetPriceByFlavourResponse Read(GetPriceByFlavour query)
        {
            var found = _dataAccessLayer.GetAll().FirstOrDefault(item => item.Flavour == query.Flavour);
            return new GetPriceByFlavourResponse(found?.Price);
        }
    }
}