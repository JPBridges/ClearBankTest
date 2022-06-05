using System;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Rules;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPaymentValidatorFactory _paymentValidatorFactory;

        public PaymentService(IAccountRepository accountRepository, IPaymentValidatorFactory paymentValidatorFactory)
        {
            _accountRepository = accountRepository ?? throw new NotImplementedException(nameof(accountRepository));
            _paymentValidatorFactory = paymentValidatorFactory ?? throw new NotImplementedException(nameof(paymentValidatorFactory));
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountRepository.GetAccount(request.DebtorAccountNumber);

            var validator = _paymentValidatorFactory.Create(request.PaymentScheme);

            var isValid = validator.Validate(request, account);

            if (!isValid)
            {
                return new MakePaymentResult { Success = false };
            }
            
            // There are a couple of things here.
            // 1. I believe it's better to have a debit/credit method on the account - it
            //    gives room for any extra domain specific validation and also makes it
            //    more explicit in code.
            // 2. By doing this we've now tied the implementation of this method to the 
            //    implementation of the account object.  We could potentially change the repository
            //    to return an IAccount and pop in a fake implementation in the tests.
            //    This lets us test each thing in isolation.  This is a judgement call
            //    and I've spent a fair amount time on this already so I'm not going to do it here.
            account.Debit(request.Amount);
            
            _accountRepository.UpdateAccount(account);

            return new MakePaymentResult { Success = true };
        }
    }
}
