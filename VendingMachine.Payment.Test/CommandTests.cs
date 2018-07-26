using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Payment.Commands;

namespace VendingMachine.Payment.Test
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void CreditCardPaymentHandler()
        {
            //init
            var dalMock = new Mock<IPaymentAccessLayer>();
            var creditCardPayment = new CreditCardPayment(2.5m);

            //act
            new CreditCardPaymentHandler(dalMock.Object).Handle(creditCardPayment);

            //assert
            dalMock.Verify(layer =>
                    layer.AddCreditPayment(It.Is<decimal>(item => item == 2.5m)),
                Times.Once);

            dalMock.Verify(layer =>
                layer.AddCashPayment(It.Is<decimal>(item => item == 2.5m)), Times.Never);
        }

        [TestMethod]
        public void CashCardPaymentHandler()
        {
            //init
            var dalMock = new Mock<IPaymentAccessLayer>();
            var cashPayment = new CashPayment(2.5m);

            //act
            new CashPaymentHandler(dalMock.Object).Handle(cashPayment);

            //assert
            dalMock.Verify(layer =>
                layer.AddCashPayment(It.Is<decimal>(item => item == 2.5m)), Times.Once);

            dalMock.Verify(layer =>
                layer.AddCreditPayment(It.Is<decimal>(item => item == 2.5m)), Times.Never);
        }
    }
}
