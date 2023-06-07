using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NaturalProducts.Management.Domain.Common;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Persistence
{
    public class NaturalProductsDbContext : DbContext
    {
        public NaturalProductsDbContext(DbContextOptions<NaturalProductsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NaturalProductsDbContext).Assembly);

            //seed data, added through migrations
            var productGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = productGuid,
                Name = "Castañas de cajú x 500 gr",
                Count = 10,
                Price = 500,
                SalePrice = 700

            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
