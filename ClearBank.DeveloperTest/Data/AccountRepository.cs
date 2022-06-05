using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountStore _accountStore;

        public AccountRepository(IAccountStoreFactory accountStoreFactory)
        {
            if (accountStoreFactory == null)
            {
                throw new ArgumentNullException(nameof(accountStoreFactory));
            }

            _accountStore = accountStoreFactory.GetAccountStore();
        }

        public Account GetAccount(string debtorAccountNumber)
        {
            return _accountStore.GetAccount(debtorAccountNumber);
        }

        public void UpdateAccount(Account account)
        {
            _accountStore.UpdateAccount(account);
        }
    }
}