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
    [Migration("20230818153712_DBExamInit")]
    partial class DBExamInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExamService.Model.Answer", b =>
                {
                    b.Property<string>("IdAnswer")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContentAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdQuestion")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdAnswer");

                    b.HasIndex("IdQuestion");

                    b.ToTable("answers");
                });

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

                    b.Property<string>("FormatExam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

            modelBuilder.Entity("ExamService.Model.OptionQuestion", b =>
                {
                    b.Property<string>("IdOptions")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContentOption")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdQuestion")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdOptions");

                    b.HasIndex("IdQuestion");

                    b.ToTable("optionQuestions");
                });

            modelBuilder.Entity("ExamService.Model.Questions", b =>
                {
                    b.Property<string>("IdQuestion")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasKey("IdQuestion");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("ExamService.Model.Answer", b =>
                {
                    b.HasOne("ExamService.Model.Questions", "questions")
                        .WithMany("answers")
                        .HasForeignKey("IdQuestion")
                        .HasConstraintName("FK_answer_questions");

                    b.Navigation("questions");
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

            modelBuilder.Entity("ExamService.Model.OptionQuestion", b =>
                {
                    b.HasOne("ExamService.Model.Questions", "questions")
                        .WithMany("op")
                        .HasForeignKey("IdQuestion")
                        .HasConstraintName("FK_op_questions");

                    b.Navigation("questions");
                });

            modelBuilder.Entity("ExamService.Model.Exams", b =>
                {
                    b.Navigation("detailExam");
                });

            modelBuilder.Entity("ExamService.Model.Questions", b =>
                {
                    b.Navigation("answers");

                    b.Navigation("detailExam");

                    b.Navigation("op");
                });
#pragma warning restore 612, 618
        }
    }
}
