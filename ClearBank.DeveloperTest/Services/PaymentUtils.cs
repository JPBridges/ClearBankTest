using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    // This is now a dead class - I would normally delete it but I thought I'd explain where
    // things have gone.
    // The get/update methods have been moved into a repository.
    // The GetAccountStore method thas been removed completely.
    // I've kept he concept of the AccountStoreFactory and account store - these could represent
    // some sort of DB abstraction - although it's questionable whether they're needed and 
    // we couldn't just subclass the IAccountRepository.
    // AccountStoreFactory now has an implementation per AccountStore type - the factory 
    // could be used to hide potentially complex setup and implementations should be switched
    // at startup via IOC.

    //    public class PaymentUtils
    //    {
    //        private readonly IAccountStoreFactory _accountStoreFactory;
    //        public PaymentUtils(IAccountStoreFactory accountStoreFactory)
    //        {
    //            _accountStoreFactory = accountStoreFactory;
    //        }

    //        public void UpdateAccount(Account account)
    //        {
    //            var store = GetAccountStore(_accountStoreFactory);
    //            store.UpdateAccount(account);
    //        }

    //        private static IAccountStore GetAccountStore(IAccountStoreFactory accountStoreFactory)
    //        {
    //            // This should all be worked out via IOC and passed into this method.
    //            IAccountStore accountStore = null;
    //            if (accountStoreFactory != null)
    //            {
    //                accountStore = accountStoreFactory.GetAccountStore();
    //            }
    //            else
    //            {
    //                var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

    //                if (dataStoreType == "Backup")
    //                {
    //                    accountStore = new BackupAccountDataStore();
    //                }
    //                else
    //                {
    //                    accountStore = new AccountDataStore();
    //                }
    //            }
    //            return accountStore;
    //        }

    //        public Account GetAccount(string debtorAccountNumber)
    //        {
    //            var store = GetAccountStore(_accountStoreFactory);
    //            return store.GetAccount(debtorAccountNumber);
    //        }
    //    }
}
