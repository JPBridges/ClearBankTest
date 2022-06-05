using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
    public interface IAccountRepository
    {
        public Account GetAccount(string debtorAccountNumber);

        public void UpdateAccount(Account account);

    }
}