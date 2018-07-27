using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Tonny", "Stark");
            _document = new Document("12345678901", Domain.Enums.EDocumentType.CPF);
            _email = new Email("ironman@marvel.com");
            _address = new Address("Road One", "1", "Center", "Malibu", "Califonia", "United States of America", "12345678");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("4554", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Stark Industries", _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscriptionNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);           
        }

        [TestMethod]
        public void ShouldReturnSuccesWhenAddSubscription()
        {
            var payment = new PayPalPayment("4554", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Stark Industries", _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}
