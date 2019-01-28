using McMaster.Extensions.CommandLineUtils;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TotalRecall.Infrastructure.DataAccess.Database;

namespace TotalRecall.Subcommands.Memory.Handlers
{
    sealed class CreateMemory
    {
        public class Request : IRequest<Response>
        {
        }

        public class Response
        {
        }

        public class PingHandler : IRequestHandler<Request, Response>
        {
            private readonly IConsole _console;
            private readonly RecallDbContext _dbContext;

            public PingHandler(IConsole console, RecallDbContext dbContext)
            {
                _console = console;
                _dbContext = dbContext;
            }
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                _console.WriteLine("Create new memory handler");
                var entity = new Core.Entities.Memory(
                    "Name test",
                    Core.Enums.Type.BlogPost,
                    new List<Core.Entities.Tag> { new Core.Entities.Tag("EfCore2.0"), new Core.Entities.Tag("ManyToManyRelation") });

                _dbContext.Memories.Add(entity);
                await _dbContext.SaveChangesAsync();
                return null;
            }
        }
    }
}
