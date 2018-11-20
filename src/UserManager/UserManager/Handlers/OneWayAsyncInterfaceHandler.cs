using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserManager.Handlers
{
    public class OneWayAsyncInterfaceHandler
    {
        public class OneWayAsyncInterfaceRequest : IRequest
        { }

        public class Handle : IRequestHandler<OneWayAsyncInterfaceRequest>
        {
            Task<Unit> IRequestHandler<OneWayAsyncInterfaceRequest, Unit>.Handle(OneWayAsyncInterfaceRequest request, CancellationToken cancellationToken)
            {
                Debug.WriteLine("Call OneWayAsyncInterfaceHandler");
                return Unit.Task;
            }
        }
    }
}
