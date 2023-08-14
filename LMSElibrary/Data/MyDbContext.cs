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
        #endregion
    }
}
