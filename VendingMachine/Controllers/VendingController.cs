using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Stock;
using VendingMachine.Stock.Commands;
using VendingMachine.Stock.Queries;
using Ximo.Cqrs;

namespace VendingMachine.Controllers
{
    public class VendingController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;

        public VendingController(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("api/Vending/GetStock")]
        public IEnumerable<CanItemDto> GetStock()
        {
            return _queryProcessor.ProcessQuery<GetAllStock,GetAllStockResponse>(new GetAllStock()).CanItemsDto;
        }

        [HttpPost]
        [Route("api/Vending/AddStock")]
        public void AddStock([FromBody] CanItemDto can)
        {
            _commandBus.Send(new AddStock(can.Flavour,can.Quantity,can.Price));
        }

        [HttpDelete]
        [Route("api/Vending/DeleteStock/{flavour}")]
        public void DeleteStock(string flavour)
        {
            _commandBus.Send(new DeleteStock(flavour));
        }
    }
}