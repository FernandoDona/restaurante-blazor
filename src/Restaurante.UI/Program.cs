using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Restaurante.Data.Data;
using Restaurante.Data.DbAccess;
using Restaurante.Data.Interfaces;
using Restaurante.UI.HttpClients;
using Restaurante.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredModal();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IProductData, ProductData>();
builder.Services.AddSingleton<ICategoryData, CategoryData>();
builder.Services.AddSingleton<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddHttpClient<AuthClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("BaseUrls").GetSection("AuthApi").Value);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
