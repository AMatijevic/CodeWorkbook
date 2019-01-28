using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TotalRecall.Core.Entities;


namespace TotalRecall.Infrastructure.DataAccess.Database.Mappings
{
    public class MemoryTagMapping : Extensions.IEntityTypeConfiguration<MemoryTag>
    {
        public void Map(EntityTypeBuilder<MemoryTag> builder)
        {
            builder.Ignore(t => t.Id);
            builder.HasKey(t => new { t.MemoryId, t.TagId });
        }
    }
}
