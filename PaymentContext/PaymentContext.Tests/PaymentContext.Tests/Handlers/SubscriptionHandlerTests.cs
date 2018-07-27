using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        //Red, Green and Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Tony";
            command.LastName = "Stark";
            command.Document = "99999999999";
            command.Email = "x";
            command.BarCode = "x";
            command.BoletoNumber = "x";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now;
            command.Total = 1;
            command.TotalPaid = 1;
            command.Payer = "Stark Industries";
            command.PayerDocument = "x";
            command.PayerDocumentType =  Domain.Enums.EDocumentType.CPF;
            command.PayerEmail = "";
            command.Street = "x";
            command.Number = "x";
            command.Neighborhood = "x";
            command.City = "x";
            command.State = "x";
            command.Country = "x";
            command.ZipCode = "x";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}
