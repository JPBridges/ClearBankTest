using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClearBank.DeveloperTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Tests.Mocks;

namespace ClearBank.DeveloperTest.Services.Tests
{
    [TestClass()]
    public class PaymentServiceTests
    {
        [TestMethod]
        public void givenAccountWithFunds_whenFasterPayment_thenSuccess()
        {
            // The problem with this is that we have a lot of hidden setup inside the
            // AccountStoreFactoryMock - it would be better if it was explicit.
            var service = new PaymentService(new AccountStoreFactoryMock());
            var request = new MakePaymentRequest
            {
                DebtorAccountNumber = "ukfp-123",
                PaymentScheme = PaymentScheme.FasterPayments,
                Amount = 50
            };

            var result = service.MakePayment(request);

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void givenUnspecifiedAccount_whenBacsPayment_thenFailure()
        {
            var service = new PaymentService();
            var request = new MakePaymentRequest();

            var result = service.MakePayment(request);

            Assert.IsFalse(result.Success);
        }
    }
}