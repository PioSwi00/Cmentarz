// <auto-generated />
using System;
using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cmentarz.Migrations
{
    [DbContext(typeof(DbCmentarzContext))]
    partial class DbCmentarzContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cmentarz.Models.Grobowiec", b =>
                {
                    b.Property<int>("IdGrobowiec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGrobowiec"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdWlasciciel")
                        .HasColumnType("int");

                    b.Property<string>("Lokalizacja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGrobowiec");

                    b.HasIndex("IdWlasciciel");

                    b.ToTable("Grobowce");
                });

            modelBuilder.Entity("Cmentarz.Models.Odwiedzajacy", b =>
                {
                    b.Property<int>("IdOdzwiedzajacy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOdzwiedzajacy"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOdzwiedzajacy");

                    b.ToTable("Odzwiedzajacy");
                });

            modelBuilder.Entity("Cmentarz.Models.OdwiedzajacyGrobowce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdGrobowiec")
                        .HasColumnType("int");

                    b.Property<int>("IdOdwiedzajacy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGrobowiec");

                    b.HasIndex("IdOdwiedzajacy");

                    b.ToTable("OdwiedzajacyGrobowce");
                });

            modelBuilder.Entity("Cmentarz.Models.Uzytkownik", b =>
                {
                    b.Property<int>("IdUzytkownik")
                        .HasColumnType("int");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUzytkownik");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("Cmentarz.Models.Wlasciciel", b =>
                {
                    b.Property<int>("IdWlasciciel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdWlasciciel"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUzytkownik")
                        .HasColumnType("int");

                    b.Property<int>("IlGrobowcow")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdWlasciciel");

                    b.HasIndex("IdUzytkownik")
                        .IsUnique();

                    b.ToTable("Wlasciciele");
                });

            modelBuilder.Entity("Cmentarz.Models.Zmarly", b =>
                {
                    b.Property<int>("IdZmarly")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataSmierci")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdZmarly");

                    b.ToTable("Zmarli");
                });

            modelBuilder.Entity("GrobowiecOdzwiedzajacy", b =>
                {
                    b.Property<int>("GrobowceIdGrobowiec")
                        .HasColumnType("int");

                    b.Property<int>("ListaOdwiedzajacyIdOdzwiedzajacy")
                        .HasColumnType("int");

                    b.HasKey("GrobowceIdGrobowiec", "ListaOdwiedzajacyIdOdzwiedzajacy");

                    b.HasIndex("ListaOdwiedzajacyIdOdzwiedzajacy");

                    b.ToTable("GrobowiecOdzwiedzajacy");
                });

            modelBuilder.Entity("Cmentarz.Models.Grobowiec", b =>
                {
                    b.HasOne("Cmentarz.Models.Wlasciciel", "Wlasciciel")
                        .WithMany("Lista_Grobowcow")
                        .HasForeignKey("IdWlasciciel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wlasciciel");
                });

            modelBuilder.Entity("Cmentarz.Models.OdwiedzajacyGrobowce", b =>
                {
                    b.HasOne("Cmentarz.Models.Grobowiec", "Grobowiec")
                        .WithMany("Odwiedzajacy_Grobowce")
                        .HasForeignKey("IdGrobowiec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cmentarz.Models.Odzwiedzajacy", "Odwiedzajacy")
                        .WithMany("Odwiedzajacy_Grobowce")
                        .HasForeignKey("IdOdwiedzajacy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grobowiec");

                    b.Navigation("Odwiedzajacy");
                });

            modelBuilder.Entity("Cmentarz.Models.Uzytkownik", b =>
                {
                    b.HasOne("Cmentarz.Models.Odzwiedzajacy", "Odwiedzajacy")
                        .WithOne("Uzytkownik")
                        .HasForeignKey("Cmentarz.Models.Uzytkownik", "IdUzytkownik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odwiedzajacy");
                });

            modelBuilder.Entity("Cmentarz.Models.Wlasciciel", b =>
                {
                    b.HasOne("Cmentarz.Models.Uzytkownik", "Uzytkownik")
                        .WithOne()
                        .HasForeignKey("Cmentarz.Models.Wlasciciel", "IdUzytkownik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("Cmentarz.Models.Zmarly", b =>
                {
                    b.HasOne("Cmentarz.Models.Grobowiec", "Grobowiec")
                        .WithMany("ListaZmarlych")
                        .HasForeignKey("IdZmarly")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grobowiec");
                });

            modelBuilder.Entity("GrobowiecOdzwiedzajacy", b =>
                {
                    b.HasOne("Cmentarz.Models.Grobowiec", null)
                        .WithMany()
                        .HasForeignKey("GrobowceIdGrobowiec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cmentarz.Models.Odzwiedzajacy", null)
                        .WithMany()
                        .HasForeignKey("ListaOdwiedzajacyIdOdzwiedzajacy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cmentarz.Models.Grobowiec", b =>
                {
                    b.Navigation("ListaZmarlych");

                    b.Navigation("Odwiedzajacy_Grobowce");
                });

            modelBuilder.Entity("Cmentarz.Models.Odzwiedzajacy", b =>
                {
                    b.Navigation("Odwiedzajacy_Grobowce");

                    b.Navigation("Uzytkownik")
                        .IsRequired();
                });

            modelBuilder.Entity("Cmentarz.Models.Wlasciciel", b =>
                {
                    b.Navigation("Lista_Grobowcow");
                });
#pragma warning restore 612, 618
        }
    }
}
