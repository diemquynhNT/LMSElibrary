﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubjectService.Data;

#nullable disable

namespace SubjectService.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230803024135_DBInit")]
    partial class DBInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SubjectService.Model.Subject", b =>
                {
                    b.Property<string>("IdSubject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSubject");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
