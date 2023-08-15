using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SubjectService.Model;

namespace SubjectService.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<BoMon> BoMons { get; set; }
        public DbSet<SubjectClass> SubjectClasses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<DetailClass> DetailClasses { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(sub =>
            {
                sub.HasOne(e => e.BoMon).
                 WithMany(e => e.subjects)
                .HasConstraintName("FK_Subject_BoMon")
                .HasForeignKey(e => e.IdBoMon);

           
            }
              
            ) ;

            modelBuilder.Entity<SubjectClass>(cl =>

                cl.HasOne(e => e.Subjects).
                   WithMany(e => e.subjectclass)
                  .HasConstraintName("FK_class_subject")
                  .HasForeignKey(e => e.IdSubject)
            );

            modelBuilder.Entity<Topic>(tp =>
            {

                tp.HasOne(e => e.subjects).
                   WithMany(e => e.topics)
                  .HasConstraintName("FK_topic_subject")
                  .HasForeignKey(e => e.IdSubject);
            });

            modelBuilder.Entity<Document>(dc =>
            {

                dc.HasOne(e => e.topics).
                   WithMany(e => e.documents)
                  .HasConstraintName("FK_documents_topic")
                  .HasForeignKey(e => e.IdTopic);

                dc.HasOne(e => e.subclass).
                   WithMany(e => e.documents)
                  .HasConstraintName("FK_documents_class")
                  .HasForeignKey(e => e.IdClass);
            });

            modelBuilder.Entity<Resources>(tp =>
            {

                tp.HasOne(e => e.documents).
                   WithMany(e => e.resources)
                  .HasConstraintName("FK_document_res")
                  .HasForeignKey(e => e.IdDocument);
            });

            modelBuilder.Entity<DetailClass>(ct =>
            {
                ct.HasOne(e => e.SubjectClass).
                   WithMany(e => e.DetailClasses)
                  .HasConstraintName("FK_detailclasst_class")
                  .HasForeignKey(e => e.IdClass);
            });
        }
    }
}
