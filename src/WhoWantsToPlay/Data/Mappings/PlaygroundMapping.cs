using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhoWantsToPlay.DomainModel.Entities;

namespace WhoWantsToPlay.Data.Mappings
{
    public class PlaygroundMapping : Extensions.IEntityTypeConfiguration<Playground>
    {
        public void Map(EntityTypeBuilder<Playground> builder)
        {
            builder.Ignore(p => p.Users);

            //var playNavigation = builder.Metadata.FindNavigation(nameof(Playground.Plays));
            //playNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
