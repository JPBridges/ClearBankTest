using System;
using System.Collections.Generic;
using System.Text;
using ClearBank.DeveloperTest.Rules;
using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Rules
{
    [TestClass]
    public class PaymentValidatorFactoryTests
    {
        [DataTestMethod]
        [DataRow(PaymentScheme.Bacs, typeof(BacsPaymentValidator))]
        [DataRow(PaymentScheme.Chaps, typeof(ChapsPaymentValidator))]
        [DataRow(PaymentScheme.FasterPayments, typeof(FasterPaymentsPaymentValidator))]
        [DataRow((PaymentScheme)5, typeof(InvalidPaymentValidator))]
        public void whenAValidatorIsCreated_thenReturnsAppropriateValidatorType(
            PaymentScheme paymentScheme,
            Type expectedValidatorType)
        {
            var validatorFactory = new PaymentValidatorFactory();

            var validator = validatorFactory.Create(paymentScheme);

            Assert.IsInstanceOfType(validator, expectedValidatorType);
        }
    }
}
