using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TotalRecall.Core.Entities;

namespace TotalRecall.Infrastructure.DataAccess.Database.Mappings
{
    public class MemoryMapping : Extensions.IEntityTypeConfiguration<Memory>
    {
        public void Map(EntityTypeBuilder<Memory> builder)
        {
            builder.OwnsOne(o => o.Length);
            builder.HasIndex(o => o.Name);

            var tagNavigation = builder.Metadata.FindNavigation(nameof(Memory.MemoryTags));
            tagNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var summeryNavigation = builder.Metadata.FindNavigation(nameof(Memory.Summarys));
            summeryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}