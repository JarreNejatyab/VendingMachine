using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Stock.Queries
{
    public class GetAllStockResponse
    {
        private GetAllStockResponse()
        {
        }

        internal GetAllStockResponse(IEnumerable<CanItem> cans)
            : this()
        {
            CanItemsDto = cans.Select(item => new CanItemDto(item.Flavour,item.Quantity,item.Price)).ToList();
        }

        public IEnumerable<CanItemDto> CanItemsDto { get; }
    }
}