using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Stock.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace VendingMachine.Stock
{
    internal interface IVendingDataAccessLayer
    {
        IEnumerable<CanItem> GetAll();
        void Delete(string flavour);
        void AddorUpdate(CanItem can);
    }
}