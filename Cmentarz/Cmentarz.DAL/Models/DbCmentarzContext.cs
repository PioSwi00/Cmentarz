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
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Odwiedzajacy> Odwiedzajacy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Zmarly> Zmarli { get; set; }
        public DbSet<Grobowiec> Grobowce { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjektTAiBCmenatrz;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grobowiec>()
        .HasMany(g => g.ListaOdwiedzajacy)
        .WithMany(o => o.Grobowce)
        .UsingEntity(j => j.ToTable("GrobowceOdwiedzajacy"));

        } 

        //Dodane
        public DbCmentarzContext(DbContextOptions options) : base(options)
        {

        }


    }
}


