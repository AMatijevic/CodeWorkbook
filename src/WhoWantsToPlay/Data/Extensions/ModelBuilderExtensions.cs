using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsToPlay.Data.Extensions
{
    public interface IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        void Map(EntityTypeBuilder<TEntity> builder);
    }

    public static class ModelBuilderExtensions
    {
        public static void AddMapping<TEntity>(this ModelBuilder modelBuilder, IEntityTypeConfiguration<TEntity> configuration)
           where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}
