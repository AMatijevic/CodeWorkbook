using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TotalRecall.Core.Entities;
using TotalRecall.Infrastructure.DataAccess.Database.Extensions;

namespace TotalRecall.Infrastructure.DataAccess.Database.Mappings
{
    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        public void Map(EntityTypeBuilder<Tag> builder)
        {
        }
    }
}