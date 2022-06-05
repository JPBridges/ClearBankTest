using ClearBank.DeveloperTest.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests.Data
{
    [TestClass]
    public  class AccountRepositoryTests
    {
        // We could add a bunch more tests here if we wanted to
        // around error handling, or any pre-conditions.  Our repository is fairly
        // simple though so this is really just here as an example.
        [TestMethod]
        public void whenGettingAccount_thenTheUnderlyingAccountStoreIsCalled()
        {
            var factory = new Mock<IAccountStoreFactory>();
            var accountStore = new Mock<IAccountStore>();

            factory
                .Setup(f => f.GetAccountStore())
                .Returns(accountStore.Object);

            var repository = new AccountRepository(factory.Object);

            repository.GetAccount("anything");

            accountStore.Verify(x => x.GetAccount("anything"), Times.Once);
        }
    }
}
