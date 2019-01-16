using McMaster.Extensions.CommandLineUtils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TotalRecall.Core.Interfaces;
using TotalRecall.Infrastructure.DataAccess.Files;

namespace TotalRecall
{
    //UsingAttributes
    internal class Program
    {
        private static Task<int> Main(string[] args)
        {
            //Very similar to ASP.NET core startup class
            return new HostBuilder()
                //Define configuration file
                //Define logging
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                })
                //Define your services (DI Container)
                .ConfigureServices((context, services) =>
                {
                    //services.AddSingleton<IGreeter, Greeter>();
                    services.AddSingleton<IFileRepository, FileRepository>();
                    services.AddMediatR();
                })
                .RunCommandLineApplicationAsync<Recall>(args);
        }
    }

    [Command(Name = "recall", Description = "upgrade you brain"),
        Subcommand(typeof(Subcommands.Memory.Command)),
        Subcommand(typeof(Subcommands.Tag.Command))]
    public class Recall//Controller
    {
        private readonly ILogger<Recall> _logger;

        public Recall(ILogger<Recall> logger)
        {
            //_greeter = greeter;
            _logger = logger;
            //_logger.LogInformation("Constructed!");
        }

        private void OnExecute(CommandLineApplication app, IConsole console)
        {
            //app.ShowHelp();
            //app.ShowHint();
            //console.BackgroundColor = ConsoleColor.DarkGreen;
            //console.WriteLine("Recall started");
        }
    }
}