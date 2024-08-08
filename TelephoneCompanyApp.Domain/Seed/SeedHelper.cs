using Microsoft.Extensions.DependencyInjection;
using TelephoneCompanyApp.Domain.Repositories.Streets;

namespace TelephoneCompanyApp.Domain.Seed
{
    public static class SeedHelper
    {
        public static void Initialize(IServiceProvider services)
        {
            new StreetSeed(services.GetService<IStreetRepository>()).Initialize();
        }
    }
}
