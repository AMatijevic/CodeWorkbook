using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TotalRecall.Core.Entities;

namespace TotalRecall.Infrastructure.DataAccess.Database.Mappings
{
    public class TagMapping : Extensions.IEntityTypeConfiguration<Tag>
    {
        public void Map(EntityTypeBuilder<Tag> builder)
        {
            var memoryNavigation = builder.Metadata.FindNavigation(nameof(Memory.MemoryTags));
            memoryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}