using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HomeBudget.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<EarningCategory> EarningCategories { get; set; }

        public DbSet<ExpenseSubCategory> ExpenseSubCategories { get; set; }
        public DbSet<EarningSubCategory> EarningSubCategories { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseCategory>().Property(expenseCategory => expenseCategory.CategoryName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ExpenseSubCategory>().Property(ex => ex.SubCategoryName).IsRequired();
            
            modelBuilder.Entity<EarningCategory>().Property(expenseCategory => expenseCategory.CategoryName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<EarningSubCategory>().Property(ex => ex.SubCategoryName).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}