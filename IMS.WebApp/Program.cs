using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;
using IMS.WebApp.Components;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IViewInventoriesByNameUseCases, ViewProductsByNameUseCases>();
builder.Services.AddTransient<IAddInventoryUserCase, AddInventoryUserCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IAddInventoryUserCase, AddInventoryUserCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();
builder.Services.AddTransient<IDeleteInventoryByIdUseCase, DeleteInventoryByIdUseCase>();

builder.Services.AddTransient<IViewProductsByNameUseCases, ViewProductsByNameUseCases>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
