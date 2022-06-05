using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
    public class InvalidPaymentValidator : IPaymentValidator
    {
        public bool Validate(MakePaymentRequest request, Account account)
        {
            return false;
        }
    }
}