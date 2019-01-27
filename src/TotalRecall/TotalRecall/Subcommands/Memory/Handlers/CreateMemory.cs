using McMaster.Extensions.CommandLineUtils;
using MediatR;
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
                _dbContext.Memories.Add(new Core.Entities.Memory("Name test", Core.Enums.Type.BlogPost));
                await _dbContext.SaveChangesAsync();
                return null;
            }
        }
    }
}
