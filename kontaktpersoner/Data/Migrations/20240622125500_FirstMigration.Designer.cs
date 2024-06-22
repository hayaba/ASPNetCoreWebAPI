﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kontaktpersoner.Data;

#nullable disable

namespace kontaktpersoner.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240622125500_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("kontaktpersoner.Data.kontaktPerson", b =>
                {
                    b.Property<int>("KontaktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("KontaktId");

                    b.ToTable("KontaktPersoner");

                    b.HasData(
                        new
                        {
                            KontaktId = 1,
                            Adresse = "Adresse 1",
                            Email = "Email 1",
                            Navn = "Person 1",
                            Telefon = "Telefon 1"
                        },
                        new
                        {
                            KontaktId = 2,
                            Adresse = "Adresse 2",
                            Email = "Email 2",
                            Navn = "Person 2",
                            Telefon = "Telefon 2"
                        },
                        new
                        {
                            KontaktId = 3,
                            Adresse = "Adresse 3",
                            Email = "Email 3",
                            Navn = "Person 3",
                            Telefon = "Telefon 3"
                        },
                        new
                        {
                            KontaktId = 4,
                            Adresse = "Adresse 4",
                            Email = "Email 4",
                            Navn = "Person 4",
                            Telefon = "Telefon 4"
                        },
                        new
                        {
                            KontaktId = 5,
                            Adresse = "Adresse 5",
                            Email = "Email 5",
                            Navn = "Person 5",
                            Telefon = "Telefon 5"
                        },
                        new
                        {
                            KontaktId = 6,
                            Adresse = "Adresse 6",
                            Email = "Email 6",
                            Navn = "Person 6",
                            Telefon = "Telefon 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
