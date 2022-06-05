using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
    public class FasterPaymentsPaymentValidator : IPaymentValidator
    {
        public bool Validate(MakePaymentRequest request, Account account)
        {
            var valid = true;

            if (account == null)
            {
                valid = false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                valid = false;
            }
            else if (account.Balance < request.Amount)
            {
                valid = false;
            }

            return valid;
        }
    }
}