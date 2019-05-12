using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WhoWantsToPlay.Data.Extensions;
using WhoWantsToPlay.Data.Mappings;
using WhoWantsToPlay.DomainModel.Entities;

namespace WhoWantsToPlay.Data
{
    public class ApplicationDbContext : IdentityUserContext<AppUser, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Playground> Playgrounds { get; set; }
        public DbSet<Play> Plays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddMapping(new PlaygroundMapping());
            modelBuilder.AddMapping(new PlayMapping());
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
                throw ex;
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
