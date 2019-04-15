using McMaster.Extensions.CommandLineUtils;
using MediatR;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TotalRecall.Core.Enums;
using TotalRecall.Core.Interfaces;
using TotalRecall.Infrastructure.DataAccess.Database;

namespace TotalRecall.Subcommands.Memory.Handlers
{
    sealed class CreateMemory
    {
        public class Request : IRequest<Response>
        {
            public string Name { get; set; }
            public Type Type { get; set; }
            public List<Core.Entities.Tag> Tags { get; set; }
            public string Url { get; set; }
        }

        public class Response
        {
        }

        public class PingHandler : IRequestHandler<Request, Response>
        {
            private readonly IConsole _console;
            private readonly RecallDbContext _dbContext;
            private readonly IFileRepository _fileRepository;

            public PingHandler(IConsole console, RecallDbContext dbContext, IFileRepository fileRepository)
            {
                _console = console;
                _dbContext = dbContext;
                _fileRepository = fileRepository;
            }
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                _console.WriteLine("Create new memory handler");
                //When memory is created I create folder for that memory
                var path = _fileRepository.CreateDirectory(request.Name);
                var summeryPath = _fileRepository.CreateFile(path);
                Process.Start("C:\\Program Files\\Notepad++\\notepad++.exe", $"\"{summeryPath}\"");

                var entity = new Core.Entities.Memory(
                    request.Name,
                    request.Type,
                    request.Tags,
                    request.Url);

                _dbContext.Memories.Add(entity);
                await _dbContext.SaveChangesAsync();


                return null;
            }
        }
    }
}
