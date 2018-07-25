using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Stock.Commands;

namespace VendingMachine.Stock.Test
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void AddStockHandlerStockHandler()
        {
            //init
            var dalMock = new Mock<IVendingDataAccessLayer>();
            var add = new AddStock("f1", 2, 4);

            //act
            new AddStockHandler(dalMock.Object).Handle(add);

            //assert
            dalMock.Verify(layer =>
                    layer.AddorUpdate(It.Is<CanItem>(item =>
                        item.Flavour == add.Flavour &&
                        item.Price == add.Price &&
                        item.Quantity == add.Quantity)),
                Times.Once);
        }

        [TestMethod]
        public void DeleteStockHandler()
        {
            //init
            var dalMock = new Mock<IVendingDataAccessLayer>();
            var delete = new DeleteStock("f1");

            //act
            new DeleteStockHandler(dalMock.Object).Handle(delete);

            //assert
            dalMock.Verify(layer =>
                layer.Delete(It.Is<string>(item => item == delete.Flavour)), Times.Never);
        }

        [TestMethod]
        public void DeleteStockHandlerWithData()
        {
            //init
            var dalMock = new Mock<IVendingDataAccessLayer>();
            dalMock.Setup(layer => layer.GetAll()).Returns(() => new List<CanItem> {new CanItem("f1",1,1)});
            var delete = new DeleteStock("f1");

            //act
            new DeleteStockHandler(dalMock.Object).Handle(delete);

            //assert
            dalMock.Verify(layer =>
                layer.Delete(It.Is<string>(item => item == delete.Flavour)), Times.Once);
        }
    }
}
