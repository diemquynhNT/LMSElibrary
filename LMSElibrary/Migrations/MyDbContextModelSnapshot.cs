﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubjectService.Data;

#nullable disable

namespace SubjectService.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SubjectService.Model.ClassAssignment", b =>
                {
                    b.Property<string>("IdPC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdLectures")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdPC");

                    b.HasIndex("IdClass");

                    b.HasIndex("IdLectures");

                    b.ToTable("classAssignments");
                });

            modelBuilder.Entity("SubjectService.Model.ClassList", b =>
                {
                    b.Property<string>("IdClassList")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdClass")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdStudent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClassList");

                    b.HasIndex("IdClass");

                    b.ToTable("classLists");
                });

            modelBuilder.Entity("SubjectService.Model.ClassSubject", b =>
                {
                    b.Property<string>("IdClass")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameClass")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClass");

                    b.ToTable("Lop");
                });

            modelBuilder.Entity("SubjectService.Model.Department", b =>
                {
                    b.Property<string>("IdDepartment")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameDepartment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDepartment");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("SubjectService.Model.DetailClass", b =>
                {
                    b.Property<string>("IdClass")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdSubject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdTeacher")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClass", "IdSubject");

                    b.HasIndex("IdSubject");

                    b.ToTable("detailClasses");
                });

            modelBuilder.Entity("SubjectService.Model.Lectures", b =>
                {
                    b.Property<string>("IdLecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassSubjectIdClass")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Describe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdTopic")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleLecture")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdLecture");

                    b.HasIndex("ClassSubjectIdClass");

                    b.HasIndex("IdTopic");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("SubjectService.Model.Questions", b =>
                {
                    b.Property<string>("IdQuestions")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContentQuestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<string>("IdPC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturesIdLecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdQuestions");

                    b.HasIndex("IdPC");

                    b.HasIndex("LecturesIdLecture");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("SubjectService.Model.Resources", b =>
                {
                    b.Property<string>("IdResources")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescribeFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormatFile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdLecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NoteRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusFile")
                        .HasColumnType("bit");

                    b.Property<string>("UserCheck")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdResources");

                    b.HasIndex("IdLecture");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("SubjectService.Model.Subject", b =>
                {
                    b.Property<string>("IdSubject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescribeSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdDepartment")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameSubject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Schoolyear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusSubject")
                        .HasColumnType("bit");

                    b.HasKey("IdSubject");

                    b.HasIndex("IdDepartment");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("SubjectService.Model.SubjectInfo", b =>
                {
                    b.Property<string>("IdSubjectInfo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContentSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdSubject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSubjectInfo");

                    b.HasIndex("IdSubject");

                    b.ToTable("subjectInfos");
                });

            modelBuilder.Entity("SubjectService.Model.Topic", b =>
                {
                    b.Property<string>("IdTopic")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdSubject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TitleTopic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTopic");

                    b.HasIndex("IdSubject");

                    b.ToTable("topics");
                });

            modelBuilder.Entity("SubjectService.Model.ClassAssignment", b =>
                {
                    b.HasOne("SubjectService.Model.ClassSubject", "classSubjects")
                        .WithMany("detailLectures")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ctbg_lop");

                    b.HasOne("SubjectService.Model.Lectures", "lectures")
                        .WithMany("detailLectures")
                        .HasForeignKey("IdLectures")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ctbaigiang_baigiang");

                    b.Navigation("classSubjects");

                    b.Navigation("lectures");
                });

            modelBuilder.Entity("SubjectService.Model.ClassList", b =>
                {
                    b.HasOne("SubjectService.Model.ClassSubject", "classSubject")
                        .WithMany("dslop")
                        .HasForeignKey("IdClass")
                        .HasConstraintName("FK_dslop_lop");

                    b.Navigation("classSubject");
                });

            modelBuilder.Entity("SubjectService.Model.DetailClass", b =>
                {
                    b.HasOne("SubjectService.Model.ClassSubject", "classsubject")
                        .WithMany("detailClass")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ctlop_lop");

                    b.HasOne("SubjectService.Model.Subject", "subject")
                        .WithMany("detailClass")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ctlop_monhoc");

                    b.Navigation("classsubject");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("SubjectService.Model.Lectures", b =>
                {
                    b.HasOne("SubjectService.Model.ClassSubject", null)
                        .WithMany("lectures")
                        .HasForeignKey("ClassSubjectIdClass");

                    b.HasOne("SubjectService.Model.Topic", "topics")
                        .WithMany("lecture")
                        .HasForeignKey("IdTopic")
                        .HasConstraintName("FK_baigiang_chude");

                    b.Navigation("topics");
                });

            modelBuilder.Entity("SubjectService.Model.Questions", b =>
                {
                    b.HasOne("SubjectService.Model.ClassAssignment", "classAssignment")
                        .WithMany("Questions")
                        .HasForeignKey("IdPC")
                        .HasConstraintName("FK_cauhoi_baigiang");

                    b.HasOne("SubjectService.Model.Lectures", null)
                        .WithMany("Questions")
                        .HasForeignKey("LecturesIdLecture");

                    b.Navigation("classAssignment");
                });

            modelBuilder.Entity("SubjectService.Model.Resources", b =>
                {
                    b.HasOne("SubjectService.Model.Lectures", "lectures")
                        .WithMany("resources")
                        .HasForeignKey("IdLecture")
                        .HasConstraintName("FK_res_baigiang");

                    b.Navigation("lectures");
                });

            modelBuilder.Entity("SubjectService.Model.Subject", b =>
                {
                    b.HasOne("SubjectService.Model.Department", "department")
                        .WithMany("subjects")
                        .HasForeignKey("IdDepartment")
                        .HasConstraintName("FK_MonHoc_BoMon");

                    b.Navigation("department");
                });

            modelBuilder.Entity("SubjectService.Model.SubjectInfo", b =>
                {
                    b.HasOne("SubjectService.Model.Subject", "subjects")
                        .WithMany("subjectInfos")
                        .HasForeignKey("IdSubject")
                        .HasConstraintName("FK_ttmh_monhoc");

                    b.Navigation("subjects");
                });

            modelBuilder.Entity("SubjectService.Model.Topic", b =>
                {
                    b.HasOne("SubjectService.Model.Subject", "subjects")
                        .WithMany("topics")
                        .HasForeignKey("IdSubject")
                        .HasConstraintName("FK_chude_monhoc");

                    b.Navigation("subjects");
                });

            modelBuilder.Entity("SubjectService.Model.ClassAssignment", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("SubjectService.Model.ClassSubject", b =>
                {
                    b.Navigation("detailClass");

                    b.Navigation("detailLectures");

                    b.Navigation("dslop");

                    b.Navigation("lectures");
                });

            modelBuilder.Entity("SubjectService.Model.Department", b =>
                {
                    b.Navigation("subjects");
                });

            modelBuilder.Entity("SubjectService.Model.Lectures", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("detailLectures");

                    b.Navigation("resources");
                });

            modelBuilder.Entity("SubjectService.Model.Subject", b =>
                {
                    b.Navigation("detailClass");

                    b.Navigation("subjectInfos");

                    b.Navigation("topics");
                });

            modelBuilder.Entity("SubjectService.Model.Topic", b =>
                {
                    b.Navigation("lecture");
                });
#pragma warning restore 612, 618
        }
    }
}
