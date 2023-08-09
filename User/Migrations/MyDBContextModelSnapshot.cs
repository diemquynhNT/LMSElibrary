﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Data;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserService.Model.Khoa", b =>
                {
                    b.Property<string>("IdKhoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameKhoa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdKhoa");

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("UserService.Model.Position", b =>
                {
                    b.Property<string>("IdPos")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NamePos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPos");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("UserService.Model.Users", b =>
                {
                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdKhoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdPos")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("ImageUser")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nameus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Numphone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdUser");

                    b.HasIndex("IdKhoa");

                    b.HasIndex("IdPos");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UserService.Model.Users", b =>
                {
                    b.HasOne("UserService.Model.Khoa", "khoas")
                        .WithMany("users")
                        .HasForeignKey("IdKhoa");

                    b.HasOne("UserService.Model.Position", "cv")
                        .WithMany("users")
                        .HasForeignKey("IdPos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cv");

                    b.Navigation("khoas");
                });

            modelBuilder.Entity("UserService.Model.Khoa", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("UserService.Model.Position", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
