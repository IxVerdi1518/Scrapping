using Microsoft.EntityFrameworkCore;
using PruebaScra.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//TENER INSTALADO DESDE EL NUGET: ENTITYFRAMEWORK, ENTITYFRAMEWORK.TOOTLS, ENTITY SQL SERVER
//Siguiente linea en la consola del nuget
//Scaffold - DbContext "Data Source=DESKTOP-PPN13H4;Initial Catalog=ScrapDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models

//En el JSON
//"ConnectionStrings": {
//    "conexion": "Data Source=DESKTOP-PPN13H4;Initial Catalog=ScrapDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
//  }

//Pegar esta linea de codigo arriba de builder.Build()
//builder.Services.AddDbContext<AuthBdtestContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ScrapDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

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

app.Run();
