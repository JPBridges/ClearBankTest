namespace ClearBank.DeveloperTest.Data
{
    // Although our implementations of this class are trivial this may not always be the case.
    // Since our account store type was chosen from the app config it's probably better to have
    // a small highly specialised factory class we can switch in with IOC than factory classes with a 
    // bunch of if statements doing fairly specialised stuff.
    // We could potentially do away with this class entirely and just merge it into IAccountStore
    // the only reason not to do this is a) if the construction of the account store is overly complex or
    // b) if we wanted to be able to create new instances of the account store on demand
    //
    // In brief - I know I've removed functionality regarding the app config - but I would make that
    // choice earlier in the application when registering the IOC container.
    public interface IAccountStoreFactory
    {
        IAccountStore GetAccountStore();
    }
}
