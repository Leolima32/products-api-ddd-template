using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Infra
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken) {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.State == EntityState.Added)
                {
                    item.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
                
                item.Property("LastUpdated").CurrentValue = DateTime.Now;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}