using BudgetMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetMvcApp.EFDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<BudgetDataModel> Budget { get; set; }
        public DbSet<BudgetExpenseDataModel> Expense { get; set; }
    }
}
