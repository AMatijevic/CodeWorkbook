using McMaster.Extensions.CommandLineUtils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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

            public PingHandler(IConsole console)
            {
                _console = console;
            }
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                _console.WriteLine("Create new memory handler");
                return null;
            }
        }
    }
}
