using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhoWantsToPlay.Data.Extensions;
using WhoWantsToPlay.DomainModel.Entities;

namespace WhoWantsToPlay.Data.Mappings
{
    public class PlayMapping : IEntityTypeConfiguration<Play>
    {
        public void Map(EntityTypeBuilder<Play> builder)
        {
            builder.HasOne(p => p.AppUser).WithMany("Plays");
            builder.HasOne(p => p.Playground).WithMany("Plays");
        }
    }
}
