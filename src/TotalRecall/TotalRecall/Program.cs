using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
                .ConfigureServices((context, services) => services.AddSingleton<IGreeter, Greeter>())
                .RunCommandLineApplicationAsync<TotalRecall>(args);
        }
    }

    [Command(Name = "recall", Description = "Dependency Injection sample project")]
    public class TotalRecall//Controller
    {
        private readonly IGreeter _greeter;
        private readonly ILogger<TotalRecall> _logger;

        public TotalRecall(IGreeter greeter, ILogger<TotalRecall> logger)
        {
            _greeter = greeter;
            _logger = logger;
            _logger.LogInformation("Constructed!");
        }

        [Argument(0, Description = "your name")]
        private string Name { get; } = "dependency injection";

        [Option("-l|--language", Description = "your desired language")]
        [AllowedValues("english", "spanish", IgnoreCase = true)]
        public string Language { get; } = "english";

        private void OnExecute(CommandLineApplication app)
        {
            //app.ShowHelp();
            //app.ShowHint();
            _greeter.Greet(Name, Language);
        }
    }


    public class Greeter:IGreeter
    {
        private readonly IConsole _console;
        private readonly ILogger<Greeter> _logger;

        public Greeter(ILogger<Greeter> logger,
            IConsole console)
        {
            _logger = logger;
            _console = console;

            _logger.LogInformation("Constructed!");
        }

        public void Greet(string name, string language = "english")
        {
            string greeting;
            switch (language)
            {
                case "english": greeting = "Hello {0}"; break;
                case "spanish": greeting = "Hola {0}"; break;
                default: throw new InvalidOperationException("validation should have caught this");
            }
            _console.WriteLine(greeting, name);
        }
    }

    public interface IGreeter
    {
        void Greet(string name, string language);
    }
}