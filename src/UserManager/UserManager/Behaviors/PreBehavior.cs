using MediatR.Pipeline;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace UserManager.Behaviors
{
    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pre processor is runing");
            return Task.CompletedTask;
        }
    }
}