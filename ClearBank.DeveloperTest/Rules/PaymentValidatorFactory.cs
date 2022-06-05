using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
    public class PaymentValidatorFactory : IPaymentValidatorFactory
    {
        public IPaymentValidator Create(PaymentScheme paymentScheme)
        {
            return paymentScheme switch
            {
                PaymentScheme.Bacs => new BacsPaymentValidator(),
                PaymentScheme.Chaps => new ChapsPaymentValidator(),
                PaymentScheme.FasterPayments => new FasterPaymentsPaymentValidator(),
                // The default option is really just demo-ing a more OO way to do an 'unhandled case'
                // We could throw here - but if we return an full blown validator object
                // then it gives us a nice place to add logging, tracing, etc, and requires no
                // special handling by the client.
                _ => new InvalidPaymentValidator()
            };
        }
    }
}