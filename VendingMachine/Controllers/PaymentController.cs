using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Payment;
using VendingMachine.Payment.Commands;
using VendingMachine.Payment.Queries;
using VendingMachine.Stock;
using VendingMachine.Stock.Commands;
using VendingMachine.Stock.Queries;
using Ximo.Cqrs;

namespace VendingMachine.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;

        public PaymentController(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("api/Payment/GetPaymentBalance")]
        public PaymentBalanceDto GetPaymentBalance()
        {
            return _queryProcessor
                .ProcessQuery<GetBalance, GetBalanceResponse>(new GetBalance()).PaymentBalance;
        }

        [HttpPost]
        [Route("api/Payment/Reset")]
        public void Reset()
        {
            _commandBus.Send(new ResetBalance());
        }

        [HttpPut]
        [Route("api/Payment/BuyWithCash")]
        public void BuyWithCash([FromBody] CanItemDto can)
        {
            if (GetPrice(can, out var price)) return;

            Debug.Assert(price != null, nameof(price) + " != null");

            if(can.Price != price.Value)
                return;

            _commandBus.Send(new CashPayment(price.Value));
            _commandBus.Send(new EjectCan(can.Flavour));
        }

        private bool GetPrice(CanItemDto can, out decimal? price)
        {
            price = _queryProcessor
                .ProcessQuery<GetPriceByFlavour, GetPriceByFlavourResponse>(new GetPriceByFlavour(can.Flavour)).Price;

            return !price.HasValue;
        }

        [HttpPut]
        [Route("api/Payment/BuyWithCredit")]
        public void BuyWithCredit([FromBody] CanItemDto can)
        {
            if (GetPrice(can, out var price)) return;

            Debug.Assert(price != null, nameof(price) + " != null");

            _commandBus.Send(new CreditCardPayment(price.Value));
            _commandBus.Send(new EjectCan(can.Flavour));
        }
    }
}