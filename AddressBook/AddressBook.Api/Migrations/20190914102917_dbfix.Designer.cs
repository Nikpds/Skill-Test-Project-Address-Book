﻿// <auto-generated />
using System;
using AddressBook.Api.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddressBook.Api.Migrations
{
    [DbContext(typeof(SqlExpressContext))]
    [Migration("20190914102917_dbfix")]
    partial class dbfix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressBook.Api.Models.AddressInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Region");

                    b.Property<string>("Town");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("AddressBook");
                });

            modelBuilder.Entity("AddressBook.Api.Models.Seriloger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception");

                    b.Property<string>("Level");

                    b.Property<string>("Message");

                    b.Property<string>("MessageTemplate");

                    b.Property<string>("Properties");

                    b.Property<DateTimeOffset>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("AddressBook.Api.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AddressBook.Api.Models.AddressInfo", b =>
                {
                    b.HasOne("AddressBook.Api.Models.User", "User")
                        .WithOne("AddressInfo")
                        .HasForeignKey("AddressBook.Api.Models.AddressInfo", "UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
