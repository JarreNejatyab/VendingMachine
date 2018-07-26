using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Payment.Queries;

namespace VendingMachine.Payment.Test
{
    [TestClass]
    public class QueriesTests
    {
        [TestMethod]
        public void CreditCardPaymentHandler()
        {
            //init
            var dalMock = new Mock<IPaymentAccessLayer>();
            var getBalance = new GetBalance();

            //act
            new GetBalanceHandler(dalMock.Object).Read(getBalance);

            //assert
            dalMock.Verify(layer =>
                    layer.GetCashBalance(),
                Times.Once);

            dalMock.Verify(layer =>
                    layer.GetCreditBalance(),
                Times.Once);
        }
    }
}
