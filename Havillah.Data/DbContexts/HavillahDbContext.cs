using Havillah.Data.AggregateRoots;
using Havillah.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Havillah.Data.DbContexts
{
    public class HavillahDbContext: DbContext
    {
        public HavillahDbContext(DbContextOptions<HavillahDbContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings here
            ConfigureAuditedEntity<Account>(modelBuilder);
        }

        // Helper method to configure audited entities

        private static void ConfigureAuditedEntity<TEntity>(ModelBuilder modelBuilder) where TEntity : AuditedAggregateRoot<int>
        {
            modelBuilder.Entity<TEntity>(entity =>
            {
                // Configure the relationship for Creator
                entity.HasOne<Account>("Creator")
                      .WithMany()
                      .HasForeignKey("CreatorId")
                      .OnDelete(DeleteBehavior.Restrict);

                // Configure the relationship for Deleter
                entity.HasOne<Account>("Deleter")
                      .WithMany()
                      .HasForeignKey("DeleterId")
                      .OnDelete(DeleteBehavior.Restrict);

                // If the entity is of type FullAuditedAggregateRoot, configure LastModifierUser
                if (typeof(FullAuditedAggregateRoot<int>).IsAssignableFrom(typeof(TEntity)))
                {
                    entity.HasOne<Account>("LastModifierUser")
                          .WithMany()
                          .HasForeignKey("LastModifierUserId")
                          .OnDelete(DeleteBehavior.Restrict);
                }
            });
        }

    }
}
