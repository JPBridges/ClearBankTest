using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Rules;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentUtils _utils;
        public PaymentService(IAccountStoreFactory accountStoreFactory)
        {
            // We never want to do this - payment utils has a bunch of bundled logic
            // that we cannot mock if we new it up in this way - better to always pass it in
            // via constructor injection.
            _utils = new PaymentUtils(accountStoreFactory);
        }
        public PaymentService()
        {
            // Same comment as above
            _utils = new PaymentUtils(null);
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            // Utils acts more like a repository. What is confusing is that it takes
            // an IAccountStoreFactory - although IAccountStoreFactory
            // behaves as more of an abstraction over the underlying data source.
            var account = _utils.GetAccount(request.DebtorAccountNumber);

            // We have one uber payment validator that we may want to split 
            // into multiple classes with a single validate.
            // Plus it been a static method is kind of a smell - it would be
            // better if it was a fully coherent object with it's own internal
            // members
            var result = new MakePaymentResult
            {
                Success = PaymentValidator.Validate(request, account)
            };

            if (!result.Success)
            {
                // Result should probably return more information although this would break
                // the interface so won't do that here
                return result;
            }

            // Maybe account should be responsible for doing this deduction
            // even though we validate it above - the account should probably ensure
            // that it is never put into an invalid state - in this case I'm not sure
            // if accounts can have a negative balance.
            account.Balance -= request.Amount;
            
            _utils.UpdateAccount(account);

            // Need to decide if exceptions thrown should be caught and result in a 
            // MakePaymentResult.Success = false, or whether we just bubble the exception.
            return result;
        }
    }
}
