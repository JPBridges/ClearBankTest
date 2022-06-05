using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
    public interface IPaymentValidatorFactory
    {
        IPaymentValidator Create(PaymentScheme paymentScheme);
    }
}