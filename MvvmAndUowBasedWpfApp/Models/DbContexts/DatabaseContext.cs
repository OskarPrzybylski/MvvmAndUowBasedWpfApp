using Microsoft.EntityFrameworkCore;

namespace MvvmAndUowBasedWpfApp.Models.DbContexts
{
    public class DatabaseContext : DbContext
    {
        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"ADD CONNECTION STRING HERE");
        }
        #endregion
    }
}
