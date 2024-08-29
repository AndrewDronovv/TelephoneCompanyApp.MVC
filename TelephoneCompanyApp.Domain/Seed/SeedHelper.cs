using Microsoft.Extensions.DependencyInjection;
using TelephoneCompanyApp.Domain.Repositories.Abonents;
using TelephoneCompanyApp.Domain.Repositories.Addresses;
using TelephoneCompanyApp.Domain.Repositories.PhoneNumbers;
using TelephoneCompanyApp.Domain.Repositories.Streets;

namespace TelephoneCompanyApp.Domain.Seed
{
    public static class SeedHelper
    {
        public static void Initialize(IServiceProvider services)
        {
            new StreetSeed(services.GetService<IStreetRepository>()).Initialize();
            new AbonentSeed(services.GetService<IAbonentRepository>()).Initialize();
            new AddressSeed(services.GetService<IAddressRepository>(), services.GetService<IStreetRepository>(), services.GetService<IAbonentRepository>()).Initialize();
            new PhoneNumberSeed(services.GetService<IPhoneNumberRepository>(), services.GetService<IAbonentRepository>()).Initialize();
        }
    }
}
