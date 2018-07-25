using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Controllers;
using VendingMachine.Stock;
using VendingMachine.Stock.Commands;
using Ximo.Cqrs;

namespace VendingMachine.Test
{
    [TestClass]
    public class VendingControllerTests
    {
        [TestMethod]
        public void AddStockTest()
        {
            var commandMock = new Mock<ICommandBus>();
            var queryMock = new Mock<IQueryProcessor>();
            
            var vendingController = new VendingController(commandMock.Object,queryMock.Object);
            var add = new CanItemDto("f1", 1, 1);

            vendingController.AddStock(add);

            commandMock.Verify(bus =>
                    bus.Send(It.Is<AddStock>(stock =>
                        stock.Flavour == add.Flavour &&
                        stock.Price == add.Price &&
                        stock.Quantity == add.Quantity)),
                Times.Once);
        }

        [TestMethod]
        public void DeleteStockTest()
        {
            var commandMock = new Mock<ICommandBus>();
            var queryMock = new Mock<IQueryProcessor>();

            var vendingController = new VendingController(commandMock.Object, queryMock.Object);
            var flavour = "f1";

            vendingController.DeleteStock(flavour);

            commandMock.Verify(bus =>
                    bus.Send(It.Is<DeleteStock>(stock =>
                        stock.Flavour == flavour )),
                Times.Once);
        }
    }
}
