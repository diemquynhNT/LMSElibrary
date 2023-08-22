using ExamService.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamService.Data
{
    public class MyDbExamContext:DbContext
    {
        public MyDbExamContext (DbContextOptions options) : base(options) { }

        #region
        public DbSet<DetailExam> detailExams { get; set; }
        public DbSet<Exams> exams { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<demo> demos { get; set; }

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

        

        }
    }
}
