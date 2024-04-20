﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eKlinika.Services.Context;

#nullable disable

namespace eKlinika.Services.Migrations
{
    [DbContext(typeof(eKlinikaContext))]
    [Migration("20240419105834_addForPacijentAndLjekarId")]
    partial class addForPacijentAndLjekarId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eKlinika.Services.Database.Ljekar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("LozinkaHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("LozinkaSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Titula")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ljekari");
                });

            modelBuilder.Entity("eKlinika.Services.Database.Nalaz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIVrijemeKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<string>("TekstualniOpis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nalazi");
                });

            modelBuilder.Entity("eKlinika.Services.Database.Pacijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Spol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pacijenti");
                });

            modelBuilder.Entity("eKlinika.Services.Database.PrijemPacijenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIVrijemePrijema")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HitniPrijem")
                        .HasColumnType("bit");

                    b.Property<int?>("NadlezniLjekarId")
                        .HasColumnType("int");

                    b.Property<int?>("PacijentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NadlezniLjekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("PrijemPacijenta");
                });

            modelBuilder.Entity("eKlinika.Services.Database.PrijemPacijenta", b =>
                {
                    b.HasOne("eKlinika.Services.Database.Ljekar", "NadlezniLjekar")
                        .WithMany()
                        .HasForeignKey("NadlezniLjekarId");

                    b.HasOne("eKlinika.Services.Database.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId");

                    b.Navigation("NadlezniLjekar");

                    b.Navigation("Pacijent");
                });
#pragma warning restore 612, 618
        }
    }
}
