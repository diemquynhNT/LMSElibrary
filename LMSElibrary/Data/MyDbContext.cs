using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SubjectService.Model;

namespace SubjectService.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<ClassSubject> classSubjects { get; set; }
        public DbSet<Topic> topics { get; set; }
        public DbSet<Lectures> lectures { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<ClassList> classLists { get; set; }
        public DbSet<DetailLectures> detailLectures { get; set; }
        public DbSet<DetailClass> detailClasses { get; set; }
        public DbSet<SubjectInfo> subjectInfos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(sub =>
            {
                sub.HasOne(e => e.department).
                 WithMany(e => e.subjects)
                .HasConstraintName("FK_MonHoc_BoMon")
                .HasForeignKey(e => e.IdDepartment);
            }
            ) ;

            modelBuilder.Entity<SubjectInfo>(t =>

               t.HasOne(e => e.subjects).
                  WithMany(e => e.subjectInfos)
                 .HasConstraintName("FK_ttmh_monhoc")
                 .HasForeignKey(e => e.IdSubject)
           );

         

            modelBuilder.Entity<Topic>(tp =>
            {
                tp.HasOne(e => e.subjects).
                   WithMany(e => e.topics)
                  .HasConstraintName("FK_chude_monhoc")
                  .HasForeignKey(e => e.IdSubject);
            });

            modelBuilder.Entity<Lectures>(dc =>
            {
                dc.HasOne(e => e.topics).
                   WithMany(e => e.lecture)
                  .HasConstraintName("FK_baigiang_chude")
                  .HasForeignKey(e => e.IdTopic);

               
            });

            modelBuilder.Entity<Resources>(tp =>
            {

                tp.HasOne(e => e.lectures).
                   WithMany(e => e.resources)
                  .HasConstraintName("FK_res_baigiang")
                  .HasForeignKey(e => e.IdLecture);
            });

            modelBuilder.Entity<DetailClass>(ct =>
            {
                ct.HasKey(t => new { t.IdClass, t.IdSubject });

                ct.HasOne(e => e.subject).
                   WithMany(e => e.detailClass)
                  .HasConstraintName("FK_ctlop_monhoc")
                  .HasForeignKey(e => e.IdSubject);

                ct.HasOne(e => e.classsubject).
                WithMany(e => e.detailClass)
               .HasConstraintName("FK_ctlop_lop")
               .HasForeignKey(e => e.IdClass);
            });

            modelBuilder.Entity<DetailLectures>(ct =>
            {
                ct.HasKey(t => new { t.IdClass, t.IdLectures });

                ct.HasOne(e => e.lectures).
                   WithMany(e => e.detailLectures)
                  .HasConstraintName("FK_ctbaigiang_baigiang")
                  .HasForeignKey(e => e.IdLectures);

                ct.HasOne(e => e.classSubjects).
                WithMany(e => e.detailLectures)
               .HasConstraintName("FK_ctbg_lop")
               .HasForeignKey(e => e.IdClass);
            });


            modelBuilder.Entity<ClassList>(t =>
            {

                t.HasOne(e => e.classSubject).
                   WithMany(e => e.dslop)
                  .HasConstraintName("FK_dslop_lop")
                  .HasForeignKey(e => e.IdClass);
            });


        }
    }
}
