using System;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Rules;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests.Services
{
    [TestClass]
    public class PaymentServiceTests
    {
        private Mock<IAccountRepository> _accountRepository;
        private PaymentService _service;
        private Mock<IPaymentValidatorFactory> _validatorFactory;
        private Mock<IPaymentValidator> _validator;
        private const string AccountNumber = "ukfp-123";


        [TestInitialize]
        public void Setup()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _validatorFactory = new Mock<IPaymentValidatorFactory>();
            _validator = new Mock<IPaymentValidator>();

            _validatorFactory
                .Setup(f => f.Create(It.IsAny<PaymentScheme>()))
                .Returns(_validator.Object);

            _accountRepository
                .Setup(r => r.GetAccount(AccountNumber))
                .Returns(new Account {Balance = 100});

            _service = new PaymentService(_accountRepository.Object, _validatorFactory.Object);

        }

        [TestMethod]
        public void givenAccountValidationPasses_whenMakingPayment_thenSuccess()
        {
            _validator
                .Setup(x => x.Validate(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
                .Returns(true);

            var request = new MakePaymentRequest { DebtorAccountNumber = AccountNumber, Amount = 100 };

            var result = _service.MakePayment(request);

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void givenAccountValidationFails_whenMakingPayment_thenFailure()
        {
            _validator
                .Setup(x => x.Validate(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
                .Returns(false);

            var request = new MakePaymentRequest { DebtorAccountNumber = AccountNumber, Amount = 100 };

            var result = _service.MakePayment(request);

            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void givenExceptionIsThrow_whenMakingPayment_thenExceptionBubblesUp()
        {
            _accountRepository
                .Setup(r => r.GetAccount(AccountNumber))
                .Throws(new Exception("oh no"));

            var request = new MakePaymentRequest { DebtorAccountNumber = AccountNumber, Amount = 100 };

            Assert.ThrowsException<Exception>(() => _service.MakePayment(request));
        }
    }
}