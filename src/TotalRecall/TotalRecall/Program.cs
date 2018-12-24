using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TotalRecall.Core.Entities;
using TotalRecall.Infrastructure.DataAccess.Database;

namespace TotalRecall
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var memoryName = "DDD";
            var cellName = "Value object in EF core";
            var cellType = Core.Enums.Type.BlogPost;

            using (var db = new TotalRecallDbContext())
            {
                db.Memories.Add(new Memory(memoryName, new Cell(cellName, cellType)));
                await db.SaveChangesAsync();
            }

        }
    }
}
