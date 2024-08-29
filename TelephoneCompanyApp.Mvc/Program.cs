using System.Data;
using System.Data.SQLite;
using TelephoneCompanyApp.Domain.Repositories.Abonents;
using TelephoneCompanyApp.Domain.Repositories.Addresses;
using TelephoneCompanyApp.Domain.Repositories.PhoneNumbers;
using TelephoneCompanyApp.Domain.Repositories.Streets;
using TelephoneCompanyApp.Domain.Seed;
using TelephoneCompanyApp.Mvc.Services.Abonents;
using TelephoneCompanyApp.Mvc.Services.Streets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));


var config = builder.Configuration;
var connectionString = config.GetConnectionString("Default");

builder.Services.AddSingleton<IDbConnection, SQLiteConnection>(c => new SQLiteConnection(connectionString));

builder.Services.AddTransient<IAbonentRepository, AbonentRepository>();
builder.Services.AddTransient<IStreetRepository, StreetRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IPhoneNumberRepository, PhoneNumberRepository>();
builder.Services.AddTransient<IAbonentService, AbonentService>();
builder.Services.AddTransient<IStreetService, StreetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var connection = app.Services.GetService<IDbConnection>();
connection.Open();

SeedHelper.Initialize(app.Services);

app.Run();