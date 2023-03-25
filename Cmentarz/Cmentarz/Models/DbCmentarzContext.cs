using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Cmentarz.Models
{
    

    public class DbCmentarzContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cmentarz;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbCmentarzContext() 
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OdwiedzajacyGrobowce>()
                  .HasOne(o => o.Odwiedzajacy)
                  .WithMany(op => op.Odwiedzajacy_Grobowce)// odwidzajacy grobowiec
                  .HasForeignKey(odi => odi.IdOdwiedzajacy);
            modelBuilder.Entity<OdwiedzajacyGrobowce>()
                   .HasOne(o => o.Grobowiec)
                   .WithMany(op => op.Odwiedzajacy_Grobowce)
                   .HasForeignKey(odi => odi.IdGrobowiec);          // n:m

                  

            modelBuilder.Entity<Wlasciciel>()
                .HasOne(w => w.Uzytkownik)                          //1:1 wlasciciel uzytkownik
                .WithOne()
                .HasForeignKey<Wlasciciel>(w => w.IdUzytkownik);

            modelBuilder.Entity<Wlasciciel>()
                .HasMany(w => w.Lista_Grobowcow)
                .WithOne(g => g.Wlasciciel)                     //1:n Wlasciciel Grobowiec
                .HasForeignKey(g => g.IdWlasciciel);

            modelBuilder.Entity<Grobowiec>()
                .HasMany(z => z.ListaZmarlych)                  //1:n Grobowiec  Zmarly
                .WithOne(g => g.Grobowiec)
                .HasForeignKey(d => d.IdZmarly);
          
            modelBuilder.Entity<Odzwiedzajacy>()
                .HasOne(o => o.Uzytkownik)
                .WithOne(u => u.Odwiedzajacy)                       //1:1 odwiedzajac uzytkwonik
                .HasForeignKey<Uzytkownik>(u => u.IdUzytkownik);
        }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Odzwiedzajacy> Odwiedzajacy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Zmarly> Zmarli { get; set; }
        public DbSet<Grobowiec> Grobowce { get; set; }
        public DbSet<OdwiedzajacyGrobowce> Odwiedzajacy_Grobowce{get;set;}

       

    }

}


