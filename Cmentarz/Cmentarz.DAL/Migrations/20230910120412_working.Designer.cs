﻿// <auto-generated />
using System;
using Cmentarz.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cmentarz.DAL.Migrations
{
    [DbContext(typeof(DbCmentarzContext))]
    [Migration("20230910120412_working")]
    partial class working
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cmentarz.DAL.Models.Grobowiec", b =>
                {
                    b.Property<int>("IdGrobowiec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGrobowiec"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("CzyZajety")
                        .HasColumnType("bit");

                    b.Property<int?>("IdWlasciciel")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Lokalizacja")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sektor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UzytkownikIdUzytkownik")
                        .HasColumnType("int");

                    b.Property<int?>("WlascicielIdWlasciciel")
                        .HasColumnType("int");

                    b.HasKey("IdGrobowiec");

                    b.HasIndex("UzytkownikIdUzytkownik");

                    b.HasIndex("WlascicielIdWlasciciel");

                    b.ToTable("Grobowce");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Odwiedzajacy", b =>
                {
                    b.Property<int>("IdOdwiedzajacy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOdwiedzajacy"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOdwiedzajacy");

                    b.ToTable("Odzwiedzajacy");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Uzytkownik", b =>
                {
                    b.Property<int>("IdUzytkownik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUzytkownik"));

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OdwiedzajacyIdOdwiedzajacy")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUzytkownik");

                    b.HasIndex("OdwiedzajacyIdOdwiedzajacy");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Wlasciciel", b =>
                {
                    b.Property<int>("IdWlasciciel")
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IlGrobowcow")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdWlasciciel");

                    b.ToTable("Wlasciciele");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Zmarly", b =>
                {
                    b.Property<int>("IdZmarly")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZmarly"));

                    b.Property<DateTime>("DataSmierci")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrobowiecID")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdZmarly");

                    b.HasIndex("GrobowiecID");

                    b.ToTable("Zmarli");
                });

            modelBuilder.Entity("GrobowiecOdwiedzajacy", b =>
                {
                    b.Property<int>("GrobowceIdGrobowiec")
                        .HasColumnType("int");

                    b.Property<int>("ListaOdwiedzajacyIdOdwiedzajacy")
                        .HasColumnType("int");

                    b.HasKey("GrobowceIdGrobowiec", "ListaOdwiedzajacyIdOdwiedzajacy");

                    b.HasIndex("ListaOdwiedzajacyIdOdwiedzajacy");

                    b.ToTable("GrobowiecOdwiedzajacy");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Grobowiec", b =>
                {
                    b.HasOne("Cmentarz.DAL.Models.Uzytkownik", null)
                        .WithMany("Grobowce")
                        .HasForeignKey("UzytkownikIdUzytkownik");

                    b.HasOne("Cmentarz.DAL.Models.Wlasciciel", null)
                        .WithMany("Grobowce")
                        .HasForeignKey("WlascicielIdWlasciciel");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Uzytkownik", b =>
                {
                    b.HasOne("Cmentarz.DAL.Models.Odwiedzajacy", "Odwiedzajacy")
                        .WithMany()
                        .HasForeignKey("OdwiedzajacyIdOdwiedzajacy");

                    b.Navigation("Odwiedzajacy");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Zmarly", b =>
                {
                    b.HasOne("Cmentarz.DAL.Models.Grobowiec", null)
                        .WithMany("Zmarli")
                        .HasForeignKey("GrobowiecID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrobowiecOdwiedzajacy", b =>
                {
                    b.HasOne("Cmentarz.DAL.Models.Grobowiec", null)
                        .WithMany()
                        .HasForeignKey("GrobowceIdGrobowiec")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cmentarz.DAL.Models.Odwiedzajacy", null)
                        .WithMany()
                        .HasForeignKey("ListaOdwiedzajacyIdOdwiedzajacy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Grobowiec", b =>
                {
                    b.Navigation("Zmarli");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Uzytkownik", b =>
                {
                    b.Navigation("Grobowce");
                });

            modelBuilder.Entity("Cmentarz.DAL.Models.Wlasciciel", b =>
                {
                    b.Navigation("Grobowce");
                });
#pragma warning restore 612, 618
        }
    }
}
