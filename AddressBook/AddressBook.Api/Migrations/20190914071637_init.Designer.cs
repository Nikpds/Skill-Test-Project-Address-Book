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
    [Migration("20190914071637_init")]
    partial class init
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

                    b.HasKey("Id");

                    b.ToTable("AddressBook");
                });

            modelBuilder.Entity("AddressBook.Api.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressInfoId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("AddressInfoId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AddressBook.Api.Models.User", b =>
                {
                    b.HasOne("AddressBook.Api.Models.AddressInfo", "AddressInfo")
                        .WithMany()
                        .HasForeignKey("AddressInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
