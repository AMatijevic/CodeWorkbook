using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TotalRecall.Infrastructure.DataAccess.Database;

namespace TotalRecall
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RecallDbContext>
    {
        public RecallDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            

            var dbOptionsBuilder = new DbContextOptionsBuilder<RecallDbContext>();
            dbOptionsBuilder.UseSqlite(configuration.GetConnectionString("RecallDb"));

            return new RecallDbContext(dbOptionsBuilder.Options);
        }
    }
}