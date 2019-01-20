using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TotalRecall.Infrastructure.DataAccess.Database
{
    public class RecallDbContext : DbContext
    {
        public RecallDbContext(DbContextOptions<RecallDbContext> options)
            :base(options)
        {

        }
    }
}
