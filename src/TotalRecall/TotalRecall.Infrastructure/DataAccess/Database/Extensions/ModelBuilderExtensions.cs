using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TotalRecall.Infrastructure.DataAccess.Database.Extensions
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