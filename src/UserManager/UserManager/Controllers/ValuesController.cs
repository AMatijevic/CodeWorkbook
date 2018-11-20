using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static UserManager.Handlers.OneWayAsyncHandler;
using static UserManager.Handlers.TwoWayPingHandler;
using static UserManager.Handlers.OneWaySyncHandler;
using static UserManager.Handlers.OneWayAsyncInterfaceHandler;

namespace UserManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var resonse = await _mediator.Send(new Ping());
            Debug.WriteLine(resonse);

            await _mediator.Send(new SyncPing());

            await _mediator.Send(new OneWay());

            await _mediator.Send(new OneWayAsyncInterfaceRequest());

            return new string[] { "value1", "value2", resonse };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
