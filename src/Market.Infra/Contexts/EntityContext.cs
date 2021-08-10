using System;
using System.Threading;
using System.Threading.Tasks;
using Market.Domain.Entities;
using Market.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Market.Infra.Contexts
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        public DbSet<StreetFair> StreetFairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StreetFairMap());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new())
        {
            SetDateEntity();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetDateEntity();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void SetDateEntity()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    var dateTime = DateTime.Now;

                    entry.Property("CreatedDate").CurrentValue = dateTime;
                    entry.Property("UpdatedDate").CurrentValue = dateTime;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                    entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }
        }
    }
}
