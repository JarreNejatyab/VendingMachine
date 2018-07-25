using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Stock
{
    internal class VendingDataAccessLayer : IVendingDataAccessLayer
    {
        private readonly IVendingStockContext _stock;

        public VendingDataAccessLayer(IVendingStockContext stock)
        {
            _stock = stock;
        }

        public IEnumerable<CanItem> GetAll()
        {
            return _stock.GetAll();
        }

        public void Delete(string flavour)
        {
            var found = _stock.GetAll().FirstOrDefault(item => item.Flavour == flavour);
            if (found == null) return;

            _stock.Remove(found);
        }

        public void AddorUpdate(CanItem can)
        {
            var found = _stock.GetAll().FirstOrDefault(item => item.Flavour.ToLower() == can.Flavour.ToLower());
            if (found == null)
                _stock.Add(can);
            else
                _stock.Update(can);
        }
    }
}