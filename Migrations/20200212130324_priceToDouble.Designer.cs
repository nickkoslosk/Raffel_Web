﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raffel_Web.Model;

namespace Raffel_Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200212130324_priceToDouble")]
    partial class priceToDouble
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Raffel_Web.Model.NetsuiteEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LAST_UPDATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("LEAD_NUMBER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MANUFACTURER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MFG_COST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PART_SUB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PRICE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PURCHASE_INFO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SALES_DES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SUB_BY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NetsuiteEntry");
                });

            modelBuilder.Entity("Raffel_Web.Model.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ENTRY_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("LEAD_NUMBER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOTES")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOTE_CREATOR")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Raffel_Web.Model.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ALPHA_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BETA_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("COMMIT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("CUSTOMER")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DATE_STARTED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DELIVERABLE")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("EE_LEAD")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<DateTime?>("FILES_TO_MANUFACTURE")
                        .HasColumnType("datetime2");

                    b.Property<string>("LEAD_NUMBER")
                        .IsRequired()
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<string>("ME_LEAD")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<string>("PART_NUMBER")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("PPAP_RCVD")
                        .HasColumnType("datetime2");

                    b.Property<string>("PRIORITY")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PROJECT_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("SALESMAN")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("TOOLING_COMPLETE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TOOLING_RELEASED")
                        .HasColumnType("datetime2");

                    b.Property<string>("USERNAME")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Raffel_Web.Model.Revision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("COMPLETE_BY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DATE_COMPLETE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_ENTERED")
                        .HasColumnType("datetime2");

                    b.Property<string>("ENTERED_BY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LEAD_NUMBER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REV_DETAILS")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Revision");
                });

            modelBuilder.Entity("Raffel_Web.Model.Scope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CONNECTIONS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUSTOMER_SCOPE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DATE_ENTERED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_NEEDED")
                        .HasColumnType("datetime2");

                    b.Property<double>("EAU")
                        .HasColumnType("float");

                    b.Property<string>("FIRST_DELIVERABLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LEAD_NUMBER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ORIGINAL_SCOPE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PRODUCT_TYPE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SCOPE_ORIGINATOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SIMILAR_TO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TARGET_PRICE")
                        .HasColumnType("float");

                    b.Property<string>("WHERE_SEND")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scope");
                });
#pragma warning restore 612, 618
        }
    }
}
