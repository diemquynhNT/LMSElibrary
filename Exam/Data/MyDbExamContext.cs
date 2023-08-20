using ExamService.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamService.Data
{
    public class MyDbExamContext:DbContext
    {
        public MyDbExamContext (DbContextOptions options) : base(options) { }

        #region
        //public DbSet<Answer> answers { get; set; }
        public DbSet<DetailExam> detailExams { get; set; }
        public DbSet<Exams> exams { get; set; }
        public DbSet<OptionQuestion> optionQuestions { get; set; }
        public DbSet<Questions> questions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailExam>(t =>
            {
                t.HasKey(t => new { t.IdQuestion, t.IdExam });
                t.HasOne(e => e.exam).
                 WithMany(e => e.detailExam)
                .HasConstraintName("FK_detailexam_exam")
                .HasForeignKey(e => e.IdExam);

                t.HasOne(e => e.questions).
                WithMany(e => e.detailExam)
               .HasConstraintName("FK_detailexam_question")
               .HasForeignKey(e => e.IdQuestion);
            }
            );

           // modelBuilder.Entity<Answer>(t =>
           // {
           //     t.HasOne(e => e.questions).
           //      WithMany(e => e.answers)
           //     .HasConstraintName("FK_answer_questions")
           //     .HasForeignKey(e => e.IdQuestion);
           // }
           //);

            modelBuilder.Entity<OptionQuestion>(sub =>
            {
                sub.HasOne(e => e.questions).
                 WithMany(e => e.op)
                .HasConstraintName("FK_op_questions")
                .HasForeignKey(e => e.IdQuestion);
            }
           );
        }
    }
}
