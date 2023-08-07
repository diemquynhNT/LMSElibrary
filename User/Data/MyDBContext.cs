using Microsoft.EntityFrameworkCore;
using UserService.Model;

namespace UserService.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region
        public DbSet<Users> users { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Khoa> khoas { get; set; }
        #endregion
    }
}
