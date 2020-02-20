using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PasswordEncripter.Entities.EF.Mappings;

namespace PasswordEncripter.Entities.EF
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<PasswordSite> PasswordSites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new PasswordSiteMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder.UseLazyLoadingProxies());
        //}
    }
}
