using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<OdwiedzajacyGrobowce>()
           .HasOne(o => o.Grobowiec)
           .WithMany(op => op.Odwiedzajacy_Grobowce)
           .HasForeignKey(odi => odi.IdGrobowiec);

    modelBuilder.Entity<OdwiedzajacyGrobowce>()
           .HasOne(o => o.Odwiedzajacy)
           .WithMany(op => op.Odwiedzajacy_Grobowce)
           .HasForeignKey(odi => odi.IdOdwiedzajacy);

    modelBuilder.Entity<Wlasciciel>()
        .HasOne(w => w.Uzytkownik)
        .WithOne()
        .HasForeignKey<Wlasciciel>(w => w.IdUzytkownik);

    modelBuilder.Entity<Wlasciciel>()
    .HasMany(w => w.Lista_Grobowcow)
    .WithOne(g => g.Wlasciciel)
    .HasForeignKey(g => g.IdWlasciciel);
    modelBuilder.Entity<Grobowiec>()
        .HasMany(z => z.ListaZmarlych)
        .WithOne(g => g.Grobowiec)
        .HasForeignKey(d => d.IdZmarly);

    modelBuilder.Entity<Odwiedzajacy>()
        .HasOne(o => o.Uzytkownik)
        .WithOne(u => u.Odwiedzajacy)
        .HasForeignKey<Odwiedzajacy>(o => o.IdOdzwiedzajacy);
}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{

    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
}
public class DbCmentarzContext : DbContext
{
   
    public DbCmentarzContext(DbContextOptions<DbCmentarzContext> options) : base(options)
    {
     
    }
   
    public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    public DbSet<Odwiedzajacy> Odwiedzajacy { get; set; }
    public DbSet<Wlasciciel> Wlasciciele { get; set; }
    public DbSet<Zmarly> Zmarli { get; set; }
    public DbSet<Grobowiec> Grobowce { get; set; }
    public DbSet<OdwiedzajacyGrobowce> Odwiedzajacy_Grobowce { get; set; }

}