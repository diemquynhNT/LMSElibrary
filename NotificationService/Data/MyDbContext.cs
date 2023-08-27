using Microsoft.EntityFrameworkCore;
using NotificationService.Model;

namespace NotificationService.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region
        public DbSet<Notifications> notifications { get; set; }
       

        #endregion

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Receiver>(t =>
        //    {
                
        //        t.HasOne(e => e.notifications).
        //         WithMany(e => e.receivers)
        //        .HasConstraintName("FK_nguoinhan_thongbao")
        //        .HasForeignKey(e => e.IdNotification);

        //    }
        //    );



        //}
    }
}
