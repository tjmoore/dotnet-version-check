using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace DotNetVersionCheck
{
    public class Program
    {
        private static VersionInfo VersionInfo { get; set; } = new VersionInfo();

        public static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand(description: "Reports .NET runtime version information and/or results in an error code useful to determine no runtime installed")
            {
                new Option(new[] { "--silent" }, "Don't write to console, just return 0 if runtime present, otherwise host will raise error code")
            };

            rootCommand.Handler = CommandHandler.Create<bool>(RootCommand);
            await rootCommand.InvokeAsync(args);

            // Normal operation returns 0. App host will return error code if there's an issue with the runtime.
            return 0;
        }

        private static void RootCommand(bool silent)
        {
            if (!silent)
            {
                Console.WriteLine($".NET Runtime Version: {VersionInfo.RuntimeVersion}");
                Console.WriteLine($".NET Target Version: {VersionInfo.TargetFramework}");
            }
        }
    }
}
