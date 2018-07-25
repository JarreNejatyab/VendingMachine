using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Stock
{
    internal class VendingStockContext : IVendingStockContext
    {
        private static readonly List<CanItem> Cans= new List<CanItem>();

        public List<CanItem> GetAll()
        {
            return Cans.Select(can => new CanItem(can.Flavour, can.Quantity, can.Price)).ToList();
        }

        public void Add(CanItem can)
        {
            Cans.Add(can);
        }

        public void Update(CanItem can)
        {
            Remove(can);
            Add(can);
        }

        public void Remove(CanItem can)
        {
            Cans.RemoveAll(item => item.Flavour == can.Flavour);
        }
    }
}