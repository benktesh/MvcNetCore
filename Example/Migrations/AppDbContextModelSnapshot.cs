﻿// <auto-generated />
using Example.Data;
using Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Example.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Example.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactType");

                    b.Property<Guid?>("DataProcessorID");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Mobile");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DataProcessorID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Example.Models.DataProcessor", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("WebSite");

                    b.HasKey("ID");

                    b.ToTable("DataProcessor");
                });

            modelBuilder.Entity("Example.Models.DPSystem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("StartDate");

                    b.Property<string>("SystemCode");

                    b.Property<string>("SystemName");

                    b.HasKey("ID");

                    b.ToTable("DPSystem");
                });

            modelBuilder.Entity("Example.Models.SystemCapablity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("SystemCapablity");
                });

            modelBuilder.Entity("Example.Models.SystemCode", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("SystemCode");
                });

            modelBuilder.Entity("Example.Models.SystemService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Core");

                    b.Property<bool>("CreditCard");

                    b.Property<bool>("LOS");

                    b.HasKey("Id");

                    b.ToTable("SystemService");
                });

            modelBuilder.Entity("Example.Models.Contact", b =>
                {
                    b.HasOne("Example.Models.DataProcessor", "DataProcessor")
                        .WithMany("Contacts")
                        .HasForeignKey("DataProcessorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}