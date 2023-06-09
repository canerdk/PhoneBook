﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneBook.Infrastructure.Persistence;

#nullable disable

namespace PhoneBook.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230529084918_29052023")]
    partial class _29052023
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhoneBook.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirsName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"),
                            Company = "Company1",
                            FirsName = "Caner",
                            LastName = "Demirkaya"
                        },
                        new
                        {
                            Id = new Guid("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"),
                            Company = "Company2",
                            FirsName = "Ahmet",
                            LastName = "Demirkaya"
                        },
                        new
                        {
                            Id = new Guid("037f21f4-ee55-47e0-9696-ab540fd71b90"),
                            Company = "Company3",
                            FirsName = "Mehmet",
                            LastName = "Demirkaya"
                        });
                });

            modelBuilder.Entity("PhoneBook.Domain.Entities.PersonContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonContacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("38a118f7-b516-47a4-9447-a3ef0732cb4c"),
                            Content = "Ankara",
                            PersonId = new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"),
                            Title = "Location",
                            Type = 3
                        },
                        new
                        {
                            Id = new Guid("117781bc-9a13-43c6-af34-047e4e93345a"),
                            Content = "5554443322",
                            PersonId = new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"),
                            Title = "Phone",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("932df542-135e-4363-b043-c61d72dd2460"),
                            Content = "3334441112",
                            PersonId = new Guid("89049e21-eb04-40b2-9add-04dc29fa7d30"),
                            Title = "Phone",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("03371521-d91b-42dd-870d-c08ed467898d"),
                            Content = "Ankara",
                            PersonId = new Guid("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"),
                            Title = "Location",
                            Type = 3
                        },
                        new
                        {
                            Id = new Guid("75441eed-49bc-407b-9318-d3f6b247e7a6"),
                            Content = "9998887744",
                            PersonId = new Guid("a2cbcfaa-e306-48bc-b1eb-0c8397b679cf"),
                            Title = "Phone",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("ce22210a-1e2a-450d-9242-fbe5a4833b07"),
                            Content = "İstanbul",
                            PersonId = new Guid("037f21f4-ee55-47e0-9696-ab540fd71b90"),
                            Title = "Location",
                            Type = 3
                        },
                        new
                        {
                            Id = new Guid("caf0dfd2-9436-4115-ab27-6b6c72df852f"),
                            Content = "9998887744",
                            PersonId = new Guid("037f21f4-ee55-47e0-9696-ab540fd71b90"),
                            Title = "Phone",
                            Type = 1
                        });
                });

            modelBuilder.Entity("PhoneBook.Domain.Entities.PersonContact", b =>
                {
                    b.HasOne("PhoneBook.Domain.Entities.Person", "Person")
                        .WithMany("PersonContacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PhoneBook.Domain.Entities.Person", b =>
                {
                    b.Navigation("PersonContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
