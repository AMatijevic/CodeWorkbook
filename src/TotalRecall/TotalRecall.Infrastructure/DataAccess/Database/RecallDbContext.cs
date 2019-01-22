using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TotalRecall.Core.Entities;
using TotalRecall.Core.SharedKernel;
using TotalRecall.Infrastructure.DataAccess.Database.Extensions;
using TotalRecall.Infrastructure.DataAccess.Database.Mappings;

namespace TotalRecall.Infrastructure.DataAccess.Database
{
    public class RecallDbContext : DbContext
    {
        public RecallDbContext(DbContextOptions<RecallDbContext> options)
            : base(options)
        { }

        public DbSet<Memory> Memories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Summary> Summaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Find types (mappings) from name-space that implement interface IEntityTypeConfiguration<T> 
            //create instance of that mapping and add that to modelBuilder
            modelBuilder.AddMapping(new MemoryMapping());
            modelBuilder.AddMapping(new SummaryMapping());
            modelBuilder.AddMapping(new TagMapping());
        }

        public async Task SaveChangesAsync()
        {
            UpdateTrackingColumns();

            try
            {
                await base.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
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