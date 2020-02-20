using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PasswordEncripter.Entities.EF.Mappings;

namespace PasswordEncripter.Entities.EF
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<PasswordSite> PasswordSites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PasswordSiteMapping);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseLazyLoadingProxies());
        }
    }
}
