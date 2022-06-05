using System.Configuration;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountStoreFactory : IAccountStoreFactory
    {
        public IAccountStore GetAccountStore()
        {
            return new AccountDataStore();
        }
    }
}