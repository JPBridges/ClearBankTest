using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Tests.Mocks
{
    internal class AccountStoreMock : IAccountStore
    {
        Account IAccountStore.GetAccount(string accountNumber)
        {
            if (accountNumber != "ukfp-123")
            {
                return null;
            }

            return new Account
            {
                AccountNumber = "ukfp-123",
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 100
            };
        }

        void IAccountStore.UpdateAccount(Account account)
        {
        }
    }

    class AccountStoreFactoryMock : IAccountStoreFactory
    {
        IAccountStore IAccountStoreFactory.GetAccountStore(string key)
        {
            return new AccountStoreMock();
        }
    }
}
