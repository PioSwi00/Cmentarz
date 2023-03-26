using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
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

           optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbCmentarzContext(DbContextOptions<DbCmentarzContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<OdwiedzajacyGrobowce>()
        //           .HasOne(o => o.Grobowiec)
        //           .WithMany(op => op.Odwiedzajacy_Grobowce)
        //           .HasForeignKey(odi => odi.IdGrobowiec);

        //    modelBuilder.Entity<OdwiedzajacyGrobowce>()
        //           .HasOne(o => o.Odwiedzajacy)
        //           .WithMany(op => op.Odwiedzajacy_Grobowce)
        //           .HasForeignKey(odi => odi.IdOdwiedzajacy);

        //    modelBuilder.Entity<Wlasciciel>()
        //        .HasOne(w => w.Uzytkownik)
        //        .WithOne()
        //        .HasForeignKey<Wlasciciel>(w => w.IdUzytkownik);

        //    modelBuilder.Entity<Wlasciciel>()
        //    .HasMany(w => w.Lista_Grobowcow)
        //    .WithOne(g => g.Wlasciciel)
        //    .HasForeignKey(g => g.IdWlasciciel);
        //    modelBuilder.Entity<Grobowiec>()
        //        .HasMany(z => z.ListaZmarlych)
        //        .WithOne(g => g.Grobowiec)
        //        .HasForeignKey(d => d.IdZmarly);
            
        //    modelBuilder.Entity<Odwiedzajacy>()
        //        .HasOne(o => o.Uzytkownik)
        //        .WithOne(u => u.Odwiedzajacy)
        //        .HasForeignKey<Odwiedzajacy>(o => o.IdOdzwiedzajacy);
        }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Odwiedzajacy> Odwiedzajacy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Zmarly> Zmarli { get; set; }
        public DbSet<Grobowiec> Grobowce { get; set; }
       

    }
 
}


