﻿using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
    public class ChapsPaymentValidator : IPaymentValidator
    {
        public bool Validate(MakePaymentRequest request, Account account)
        {
            var valid = true;

            if (account == null)
            {
                valid = false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
            {
                valid = false;
            }
            else if (account.Status != AccountStatus.Live)
            {
                valid = false;
            }

            return valid;
        }
    }
}