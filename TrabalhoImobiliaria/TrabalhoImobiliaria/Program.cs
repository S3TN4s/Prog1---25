using Modelo;
using Repository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Property}/{action=Index}/{id?}");

FillCategoryData();
FillAddressData();


app.Run();


static void FillCategoryData()
{
    for (int i = 1; i <= 5; i++)
    {
        Category category = new()
        {
            Id = i,
            Name = $"Category {i}"
        };
        CategoryData.Categorias.Add(category);
    }
}

static void FillAddressData()
{
    for (int i = 1; i <= 5; i++)
    {
        Address address = new()
        {
            Id = i,
            AddressType = "Casa",
            City = "Videira",
            Country = "HU3HU3BR",
            State = "SC",
            PostalCode = "89560-000",
            Street = "Rua da minha casa",
            Number = i
        };
        AddressData.Addresses.Add(address);
    };
}


