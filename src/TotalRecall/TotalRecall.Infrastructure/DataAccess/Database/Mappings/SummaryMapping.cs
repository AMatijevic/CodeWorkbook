using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TotalRecall.Core.Entities;
using TotalRecall.Infrastructure.DataAccess.Database.Extensions;

namespace TotalRecall.Infrastructure.DataAccess.Database.Mappings
{
    public class SummaryMapping : IEntityTypeConfiguration<Summary>
    {
        public void Map(EntityTypeBuilder<Summary> builder)
        {
        }
    }
}
