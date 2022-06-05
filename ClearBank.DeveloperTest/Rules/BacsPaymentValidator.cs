using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
    public class BacsPaymentValidator : IPaymentValidator
    {
        public bool Validate(MakePaymentRequest request, Account account)
        {
            var valid = true;

            if (account == null)
            {
                valid = false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
            {
                valid = false;
            }

            return valid;
        }
    }
}