using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Controllers;
using VendingMachine.Payment;
using VendingMachine.Payment.Commands;
using VendingMachine.Stock;
using VendingMachine.Stock.Commands;
using VendingMachine.Stock.Queries;
using Ximo.Cqrs;

namespace VendingMachine.Test
{
    [TestClass]
    public class PaymentControllerTests
    {
        [TestMethod]
        public void BuyWithCashTestCorrectPrice()
        {
            //init
            var commandMock = new Mock<ICommandBus>();
            var queryMock = new Mock<IQueryProcessor>();

            const decimal price = 12.2m;

            queryMock.Setup(processor =>
                processor.ProcessQuery<GetPriceByFlavour, GetPriceByFlavourResponse>(
                    It.Is<GetPriceByFlavour>(byFlavour => byFlavour.Flavour == "f1"))).Returns(() => new GetPriceByFlavourResponse(price));

            var paymentController = new PaymentController(commandMock.Object,queryMock.Object);
            var buy = new CanItemDto("f1", 1, price);

            //act
            paymentController.BuyWithCash(buy);


            //verify
            commandMock.Verify(bus =>
                    bus.Send(It.Is<CashPayment>(payment =>
                        payment.AmountToPay == price)),
                Times.Once);

            commandMock.Verify(bus =>
                    bus.Send(It.Is<EjectCan>(stock =>
                        stock.Flavour == buy.Flavour)),
                Times.Once);
        }

        [TestMethod]
        public void BuyWithCreditTestCorrectPrice()
        {
            //init
            var commandMock = new Mock<ICommandBus>();
            var queryMock = new Mock<IQueryProcessor>();

            const decimal price = 12.2m;

            queryMock.Setup(processor =>
                processor.ProcessQuery<GetPriceByFlavour, GetPriceByFlavourResponse>(
                    It.Is<GetPriceByFlavour>(byFlavour => byFlavour.Flavour == "f1"))).Returns(() => new GetPriceByFlavourResponse(price));

            var paymentController = new PaymentController(commandMock.Object, queryMock.Object);
            var buy = new CanItemDto("f1", 1, price);

            //act
            paymentController.BuyWithCredit(buy);

            //verify
            commandMock.Verify(bus =>
                    bus.Send(It.Is<CashPayment>(payment =>
                        payment.AmountToPay == price)),
                Times.Never);

            commandMock.Verify(bus =>
                    bus.Send(It.Is<CreditCardPayment>(payment =>
                        payment.AmountToPay == price)),
                Times.Once);

            commandMock.Verify(bus =>
                    bus.Send(It.Is<EjectCan>(stock =>
                        stock.Flavour == buy.Flavour)),
                Times.Once);
        }

        [TestMethod]
        public void BuyWithCashTestWrongPrice()
        {
            //init
            var commandMock = new Mock<ICommandBus>();
            var queryMock = new Mock<IQueryProcessor>();

            const decimal wrongPrice = 12.2m;
            const decimal correctPrice = 13.2m;

            queryMock.Setup(processor =>
                    processor.ProcessQuery<GetPriceByFlavour, GetPriceByFlavourResponse>(
                        It.Is<GetPriceByFlavour>(byFlavour =>
                            byFlavour.Flavour == "f1")))
                .Returns(() =>
                    new GetPriceByFlavourResponse(correctPrice))
                .Verifiable();

            var paymentController = new PaymentController(commandMock.Object, queryMock.Object);
            var buy = new CanItemDto("f1", 1, wrongPrice);

            //act
            paymentController.BuyWithCash(buy);

            //verify
            commandMock.Verify(bus =>
                    bus.Send(It.Is<CashPayment>(payment =>
                        payment.AmountToPay == wrongPrice)),
                Times.Never);

            commandMock.Verify(bus =>
                    bus.Send(It.Is<EjectCan>(stock =>
                        stock.Flavour == buy.Flavour)),
                Times.Never);
        }

    }
}
