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
    [Migration("20191009160927_AddRevisionsToDB")]
    partial class AddRevisionsToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Raffel_Web.Model.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ENTRY_DATE");

                    b.Property<string>("LEAD_NUMBER");

                    b.Property<string>("NOTES")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Raffel_Web.Model.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ALPHA_DATE");

                    b.Property<DateTime?>("BETA_DATE");

                    b.Property<DateTime?>("COMMIT_DATE");

                    b.Property<string>("CUSTOMER")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DATE_STARTED");

                    b.Property<string>("DELIVERABLE")
                        .HasMaxLength(20);

                    b.Property<string>("EE_LEAD")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<DateTime?>("FILES_TO_MANUFACTURE");

                    b.Property<string>("LEAD_NUMBER")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<string>("ME_LEAD")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<string>("PART_NUMBER")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("PPAP_RCVD");

                    b.Property<string>("PRIORITY")
                        .HasMaxLength(20);

                    b.Property<string>("PROJECT_NAME")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("SALESMAN")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("TOOLING_COMPLETE");

                    b.Property<DateTime?>("TOOLING_RELEASED");

                    b.Property<string>("USERNAME")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Raffel_Web.Model.Revision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("COMPLETE_BY");

                    b.Property<DateTime>("DATE_COMPLETE");

                    b.Property<DateTime?>("DATE_STARTED");

                    b.Property<string>("LEAD_NUMBER");

                    b.Property<string>("ORIGINAL_SCOPE");

                    b.Property<DateTime>("REQ_REV_DATE");

                    b.Property<DateTime>("REVISION_DATE");

                    b.Property<string>("REV_DETAILS");

                    b.HasKey("Id");

                    b.ToTable("Revision");
                });

            modelBuilder.Entity("Raffel_Web.Model.Scope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("COMPLETE_BY");

                    b.Property<DateTime>("DATE_COMPLETE");

                    b.Property<DateTime?>("DATE_STARTED");

                    b.Property<string>("LEAD_NUMBER");

                    b.Property<string>("ORIGINAL_SCOPE");

                    b.HasKey("Id");

                    b.ToTable("Scope");
                });
#pragma warning restore 612, 618
        }
    }
}
