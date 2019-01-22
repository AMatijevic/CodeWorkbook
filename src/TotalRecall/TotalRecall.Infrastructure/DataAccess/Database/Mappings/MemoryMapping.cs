using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TotalRecall.Core.Entities;
using TotalRecall.Infrastructure.DataAccess.Database.Extensions;

namespace TotalRecall.Infrastructure.DataAccess.Database.Mappings
{
    public class MemoryMapping : IEntityTypeConfiguration<Memory>
    {
        public void Map(EntityTypeBuilder<Memory> builder)
        {
            builder.OwnsOne(o => o.Length);
            builder.HasIndex(o => o.Name);
        }
    }
}