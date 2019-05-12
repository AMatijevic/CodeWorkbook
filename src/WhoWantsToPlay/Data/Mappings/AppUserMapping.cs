using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhoWantsToPlay.DomainModel.Entities;

namespace WhoWantsToPlay.Data.Mappings
{
    public class AppUserMapping : Extensions.IEntityTypeConfiguration<AppUser>
    {
        public void Map(EntityTypeBuilder<AppUser> builder)
        {
        }
    }
}
