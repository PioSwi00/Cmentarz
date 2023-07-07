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

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cmentarz;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     
        } 

        //Dodane
        public DbCmentarzContext(DbContextOptions options) : base(options)
        {

        }


    }
}


