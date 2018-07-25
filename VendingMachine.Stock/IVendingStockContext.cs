using System.Collections.Generic;

namespace VendingMachine.Stock
{
    internal interface IVendingStockContext
    {
        List<CanItem> GetAll();
        void Add(CanItem can);
        void Remove(CanItem can);
        void Update(CanItem can);
    }
}