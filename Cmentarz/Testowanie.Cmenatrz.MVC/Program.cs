using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Cmentarz.DAL.Repositories;
using Cmentarz.DAL.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add dependency injection for IGrobowiecService
builder.Services.AddScoped<IGrobowiecService, GrobowiecService>();
builder.Services.AddScoped<IUnitOfWork, UoW>();  
builder.Services.AddScoped<IZmarlyService, ZmarlyService>();
builder.Services.AddScoped<IUzytkownikService, UzytkownikService>();
builder.Services.AddScoped<IOdwiedzajacyService, OdwiedzajacyService>();
builder.Services.AddDbContext<DbCmentarzContext>();
builder.Services.AddScoped<IWlascicielService, WlascicielService>();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
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

app.UseCors( x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "odwiedzajacy",
    pattern: "Odwiedzajacy/{action=Index}/{id?}",
    defaults: new { controller = "Odwiedzajacy" });

app.MapControllerRoute(
    name: "grobowce",
    pattern: "Grobowce/{action=Index}/{id?}",
    defaults: new { controller = "Grobowce" });
app.Run();
