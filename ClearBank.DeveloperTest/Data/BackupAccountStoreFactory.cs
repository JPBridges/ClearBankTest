namespace ClearBank.DeveloperTest.Data
{
    public class BackupAccountStoreFactory : IAccountStoreFactory
    {
        public IAccountStore GetAccountStore()
        {
            return new BackupAccountDataStore();
        }
    }
}