using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace UserManager.Handlers
{
    public class OneWayAsyncHandler
    {
        public class OneWay : IRequest
        { }

        public class OneWayHandle : AsyncRequestHandler<OneWay>
        {
            protected override Task Handle(OneWay request, CancellationToken cancellationToken)
            {
                Debug.WriteLine("Async one way handler");
                return Task.CompletedTask;
            }
        }
    }
}