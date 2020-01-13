using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Windows;

namespace DotNetVersionCheck
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private VersionInfo VersionInfo { get; set; } = new VersionInfo();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var rootCommand = new RootCommand(description: "Reports .NET runtime version information and triggers a prompt to install .NET Core runtime if applicable")
            {
                new Option(new[] { "--no-window" }, "Don't display window, write version information to console"),
                new Option(new[] { "--silent" }, "Don't display window or write to console. Useful to only trigger .NET Core install if necessary")
            };

            rootCommand.Handler = CommandHandler.Create<bool, bool>(RootCommand);
            int result = rootCommand.Invoke(e.Args);
            
            if (result == 1 || e.Args.Any(a => a.Contains("--help") || a.Contains("-h") || a.Contains("--version")))
            {
                Shutdown();
            }
            else
            {
                var wnd = new MainWindow() { VersionInfo = VersionInfo };
                wnd.Show();
            }
        }

        private int RootCommand(bool noWindow, bool silent)
        {
            if (noWindow)
            {
                Console.WriteLine($".NET Runtime Version: {VersionInfo.RuntimeVersion}");
                Console.WriteLine($".NET Target Version: {VersionInfo.TargetFramework}");
            }

            if (noWindow || silent)
                return 1;

            return 0;
        }
    }
}
