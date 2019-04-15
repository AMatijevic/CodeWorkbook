using McMaster.Extensions.CommandLineUtils;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TotalRecall.Subcommands.Memory.Handlers;

namespace TotalRecall.Subcommands.Memory
{
    public abstract class BaseCommand
    {
        protected readonly IMediator _mediator;
        public BaseCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Argument(0, Description = "memory type")]
        [Required]
        //Add your own validation for this because we don't have enum validation
        protected Core.Enums.Type Type { get; }

        //To add string with space, string need to be inside ""
        [Argument(1, Description = "memory name")]
        [Required]
        protected string Name { get; }

        private List<string> _tags = new List<string>();
        [Option("-t|--tags")]
        //[Required] tags are required only when we add new memory not when we edit or delete
        protected List<string> Tags {
            get
            {
                var tags = _tags.FirstOrDefault();
                return tags?.Split(',')?.Select(t => t.Trim()).ToList() ?? new List<string>();
            }
            set
            {
                _tags = value;
            }
        }
    }

    [Command(Name = "memory", Description = "work with memories"), 
        Subcommand(typeof(AddMemory)),
        Subcommand(typeof(EditMemory))]
    public sealed class Command
    {
        [Command(Name = "add", Description = "add new memory")]
        public class AddMemory : BaseCommand
        {
            [Option("-u|--url")]
            protected string Url { get; }

            public AddMemory(IMediator mediator) : base(mediator) { }

            private new async Task OnExecute(CommandLineApplication app, IConsole console)
            {
                var request = new CreateMemory.Request
                {
                    Name = Name,
                    Type = Type,
                    Tags = Tags.Select(t => new Core.Entities.Tag(t)).ToList(),
                    Url = Url
                    
                };
                var response = await _mediator.Send(request);
            }
        }

        [Command(Name = "edit", Description = "edit existing memory")]
        public class EditMemory : BaseCommand
        {
            public EditMemory(IMediator mediator) : base(mediator) { }

            private new async Task OnExecute(CommandLineApplication app, IConsole console)
            {
                //Fill request for 
                console.WriteLine($"Selected type: {Type}");
                console.WriteLine($"memory name: {Name}");
                console.WriteLine($"tags: {string.Join(',', Tags)}");
                //var response = await _mediator.Send(new UpdateMemory.Request());
            }
        }
    }
}
