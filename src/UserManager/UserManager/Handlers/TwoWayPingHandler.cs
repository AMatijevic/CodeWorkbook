using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserManager.Handlers
{
    public class TwoWayPingHandler
    {
        /// <summary>
        /// Define object for input 
        /// That will be request
        /// But this generic string type means that response will be string
        /// </summary>
        public class Ping : IRequest<string>
        {

        }

        public class Handle : IRequestHandler<Ping, string>
        {
            Task<string> IRequestHandler<Ping, string>.Handle(Ping request, CancellationToken cancellationToken)
            {
                return Task.FromResult("Pong");
            }
        }
    }
}
