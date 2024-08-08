using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using TelephoneCompanyApp.Domain.Repositories.Abonents;
using TelephoneCompanyApp.Domain.Repositories.Streets;
using TelephoneCompanyApp.Domain.Seed;
using System.Data.SQLite;

namespace TelephoneCompanyApp.Wpf
{

    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {
            var builder = Host.CreateDefaultBuilder();
            AppHost = builder
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;
                    var connectionString = config.GetConnectionString("Default");
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<IAbonentRepository, AbonentRepository>(a => new AbonentRepository(new SQLiteConnection(connectionString)));
                    services.AddTransient<IStreetRepository, StreetRepository>(a => new StreetRepository(new SQLiteConnection(connectionString)));
                })
            .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            SeedHelper.Initialize(AppHost.Services);

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }
}
