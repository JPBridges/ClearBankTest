using ClearBank.DeveloperTest.Rules;
using ClearBank.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Rules
{
    [TestClass]
    public class BacsPaymentValidatorTests
    {
        private BacsPaymentValidator _validator;
        private MakePaymentRequest _request;

        [TestInitialize]
        public void Setup()
        {
            _validator = new BacsPaymentValidator();
            _request = new MakePaymentRequest();
        }

        [TestMethod]
        public void givenAccountIsNull_whenValidating_thenInvalid()
        {
            Account account = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var isValid = _validator.Validate(_request, account);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void givenAccountDoesNotSupportBacs_whenValidating_thenInvalid()
        {
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps
            };

            // ReSharper disable once ExpressionIsAlwaysNull
            var isValid = _validator.Validate(_request, account);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void givenValidInput_whenValidating_thenValid()
        {
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };

            // ReSharper disable once ExpressionIsAlwaysNull
            var isValid = _validator.Validate(_request, account);

            Assert.IsTrue(isValid);
        }
    }
}