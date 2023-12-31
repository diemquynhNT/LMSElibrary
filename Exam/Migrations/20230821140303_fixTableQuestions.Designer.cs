﻿// <auto-generated />
using System;
using ExamService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamService.Migrations
{
    [DbContext(typeof(MyDbExamContext))]
    [Migration("20230821140303_fixTableQuestions")]
    partial class fixTableQuestions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExamService.Model.DetailExam", b =>
                {
                    b.Property<string>("IdQuestion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdExam")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdQuestion", "IdExam");

                    b.HasIndex("IdExam");

                    b.ToTable("detailExams");
                });

            modelBuilder.Entity("ExamService.Model.Exams", b =>
                {
                    b.Property<string>("IdExam")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateExam")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FormatExam")
                        .HasColumnType("bit");

                    b.Property<string>("FormatFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdTeacher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameExam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StatusExam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TimeExam")
                        .HasColumnType("int");

                    b.HasKey("IdExam");

                    b.ToTable("exams");
                });

            modelBuilder.Entity("ExamService.Model.Questions", b =>
                {
                    b.Property<string>("IdQuestion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnswerQuestions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChoiceA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChoiceB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChoiceC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChoiceD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentQuestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdMon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUserUpdate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelQuestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("STT")
                        .HasColumnType("int");

                    b.HasKey("IdQuestion");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("ExamService.Model.DetailExam", b =>
                {
                    b.HasOne("ExamService.Model.Exams", "exam")
                        .WithMany("detailExam")
                        .HasForeignKey("IdExam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_detailexam_exam");

                    b.HasOne("ExamService.Model.Questions", "questions")
                        .WithMany("detailExam")
                        .HasForeignKey("IdQuestion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_detailexam_question");

                    b.Navigation("exam");

                    b.Navigation("questions");
                });

            modelBuilder.Entity("ExamService.Model.Exams", b =>
                {
                    b.Navigation("detailExam");
                });

            modelBuilder.Entity("ExamService.Model.Questions", b =>
                {
                    b.Navigation("detailExam");
                });
#pragma warning restore 612, 618
        }
    }
}
