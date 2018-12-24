using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Threading.Tasks;
using TotalRecall.Core.Entities;

namespace TotalRecall.Infrastructure.DataAccess.Database
{
    public class TotalRecallDbContext : DbContext
    {
        public DbSet<Memory> Memories { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Repositories\\Osobno\\FileDBs\\totalRecall.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cell>(ConfigureCell);
            builder.Entity<Memory>(ConfigureMemory);
        }

        private void ConfigureCell(EntityTypeBuilder<Cell> builder)
        {
            builder.OwnsOne(o => o.Length);
            builder.HasIndex(c => c.Title);
        }
        private void ConfigureMemory(EntityTypeBuilder<Memory> builder)
        {
            builder.HasIndex(c => c.Name);
        }

        public async Task SaveChangesAsync()
        {
            UpdateTrackingColumns();
            await base.SaveChangesAsync();
        }

        private void UpdateTrackingColumns()
        {
            foreach (var model in ChangeTracker.Entries<BaseEntity>())
            {
                var now = DateTime.UtcNow;
                switch (model.State)
                {
                    case EntityState.Added:
                        model.CurrentValues[nameof(model.Entity.Created)] = now; 
                        model.CurrentValues[nameof(model.Entity.Edited)] = now;
                        break;

                    case EntityState.Modified:
                        model.CurrentValues[nameof(model.Entity.Edited)] = now;
                        break;
                }
            }
        }
    }
}