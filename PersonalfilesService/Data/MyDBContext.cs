using Microsoft.EntityFrameworkCore;
using PersonalfilesService.Model;

namespace PersonalfilesService.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options) :base(options) { }

        #region
        public DbSet<FileDetails> fileDetails { get; set; }
        #endregion

    }
}
