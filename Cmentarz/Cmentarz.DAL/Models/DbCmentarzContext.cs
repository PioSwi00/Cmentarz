using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Cmentarz.Models
{
    public class DbCmentarzContext : DbContext
    {
        public DbCmentarzContext(DbContextOptions<DbCmentarzContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Uzytkownik>().HasData(
                new Uzytkownik
                {
                    IdUzytkownik = 1,
                    Login = "testowy",
                    Haslo = "testoweHaslo",
                    Wlasciciel = new Wlasciciel
                    {
                        IdWlasciciel = 1,
                        Imie = "Jan",
                        Nazwisko = "Kowalski",
                        Adres = "ul. Testowa 1",
                        IlGrobowcow = 1,
                        Grobowce = new List<Grobowiec> { new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1, Lokalizacja = "A1", Cena = 1000, CzyZajety = false } },
                        Uzytkownik = new Uzytkownik { IdUzytkownik = 1 }
                    },
                    Odwiedzajacy = new Odwiedzajacy
                    {
                        IdOdzwiedzajacy = 1,
                        Imie = "Adam",
                        Nazwisko = "Nowak"
                    }
                }
            );
            modelBuilder.Entity<Odwiedzajacy>().HasData(
                        new Odwiedzajacy
                        {
                            IdOdzwiedzajacy = 1,
                            Imie = "Adam",
                            Nazwisko = "Nowak"
                        }
                        );

            modelBuilder.Entity<Uzytkownik>().HasData(
                new Uzytkownik
                {
                    IdUzytkownik = 1,
                    Login = "testowy",
                    Haslo = "testoweHaslo",
                    Wlasciciel = new Wlasciciel
                    {
                        IdWlasciciel = 1,
                        Imie = "Jan",
                        Nazwisko = "Kowalski",
                        Adres = "ul. Testowa 1",
                        IlGrobowcow = 1,
                        Grobowce = new List<Grobowiec> { new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1, Lokalizacja = "A1", Cena = 1000 } },
                        Uzytkownik = new Uzytkownik { IdUzytkownik = 1 }
                    },
                   
                }
            );



        }


        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Odwiedzajacy> Odwiedzajacy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Zmarly> Zmarli { get; set; }
        public DbSet<Grobowiec> Grobowce { get; set; }
       

    }
 
}


