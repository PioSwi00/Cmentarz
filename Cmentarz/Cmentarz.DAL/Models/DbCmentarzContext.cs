using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Cmentarz.DAL.Models
{
    public class DbCmentarzContext : DbContext
    {
        public DbCmentarzContext(DbContextOptions<DbCmentarzContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            
               optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cmentarzysko;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); //dodaj swoj¹ connection string
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*var zmarliList = new List<Zmarly>
            {
                new Zmarly { IdZmarly = 1, Imie = "Jan", Nazwisko = "Kowalski", DataUrodzenia = new DateTime(1990, 1, 1), DataSmierci = new DateTime(2022, 3, 20),GrobowiecID=1},
                new Zmarly { IdZmarly = 2, Imie = "Anna", Nazwisko = "Nowak", DataUrodzenia = new DateTime(1980, 2, 2), DataSmierci = new DateTime(2022, 3, 22),GrobowiecID = 2 },
                new Zmarly { IdZmarly = 3, Imie = "Piotr", Nazwisko = "Kaminski", DataUrodzenia = new DateTime(1970, 3, 3), DataSmierci = new DateTime(2022, 3, 24), GrobowiecID = 3}
            };

            modelBuilder.Entity<Wlasciciel>()
                        .HasData(new Wlasciciel { Imie = "Adam", Nazwisko = "Nowacki", IdWlasciciel = 1, Adres = "Jakis", IlGrobowcow = 2, Uzytkownik = new Uzytkownik { IdUzytkownik = 1, Login = "ss", Haslo = "ss", Grobowce = null, Odwiedzajacy = null, Wlasciciel = null }, Grobowce = new List<Grobowiec> { new Grobowiec { Cena = 2, IdGrobowiec = 1, IdWlasciciel = null, ListaOdwiedzajacy = null, Lokalizacja = "Test", Zmarli = zmarliList } } });
            modelBuilder.Entity<Zmarly>()
                         .HasData(zmarliList);


            modelBuilder.Entity<Grobowiec>()
                .HasData(
                    new Grobowiec { Cena = 2, IdGrobowiec = 1, IdWlasciciel = 1, ListaOdwiedzajacy = null, Lokalizacja = "Test", Zmarli = zmarliList }

                );*/
        }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Odwiedzajacy> Odwiedzajacy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Zmarly> Zmarli { get; set; }
        public DbSet<Grobowiec> Grobowce { get; set; }
       

    }
 
}


