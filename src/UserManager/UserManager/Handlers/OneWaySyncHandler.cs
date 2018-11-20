using MediatR;
using System.Diagnostics;

namespace UserManager.Handlers
{
    public class OneWaySyncHandler
    {
        public class SyncPing : IRequest
        {
        }

        public class SyncHandle : RequestHandler<SyncPing>
        {
            protected override void Handle(SyncPing request)
            {
                Debug.WriteLine("Sync handler response");
            }
        }
    }
}