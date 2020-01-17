# dotnet-version-check

![](https://github.com/tjmoore/dotnet-version-check/workflows/build/badge.svg)

Sample apps to simply report .NET runtime version information and can aid with an installer to check runtime presence. This simply relies on .NET Core 3 app host ability to check runtime and report error or display a prompt to download the runtime.

A use case for this is with an installer that installs a .NET Core FDD/FDE service but needs to check and install the runtime prior to starting the service, or likewise with a console or desktop app, but not wanting to wait for a prompt or error when the user launches the app itself, but install the runtime during install.

## Update

Note: The built-in app host checks only check for the runtime required for the executable, which means for a console app it only requires the base .NET Core runtime. For a Windows app it requires .NET Core Desktop runtime and if the base runtime or hosting runtime is installed, this may still fail.

Not sure if different error codes returned can indicate what it missing or if using a Windows app to at least check the basic runtime is present or missing.

## Samples

There are two samples here:

### Console

This version is simply a console app and writes version info to the console. If the runtime is not present the dotnet host will report an error with advice to the console and will return an error code, which is one of https://github.com/dotnet/runtime/blob/master/docs/design/features/host-error-codes.md

For example, CoreHostLibMissingFailure (0x80008083) or FrameworkMissingFailure (0x80008096) can indicate a compatible runtime required based on the target is not present. An installer could check this and then run the required installer.

### WindowsWithPrompt

This version is built as a basic WPF windows app to do the same thing but shows a window with the runtime information. Perhaps useful for support scenarios.

The key here though is when built as a WinEXE output type, the dotnet host will provide a prompt to the user to download the runtime if not present. Although currently it only directs the user's browser to the runtime download home page.


### Usage

```
Usage:
  dotnet-version-check(-win|-console) [options]

Options:
  --no-window    Don't display window, write version information to console (Windows app only)
  --silent       Don't display window or write to console. Useful to only trigger .NET Core install if necessary (windows) or raise error code (windows & console)
  --version      Display version information
```

This relies on .NET Core 3+ built-in support for prompting download and install of .NET Core runtime if not installed when running an executable. This only occurs with Windows GUI Executables.

Note, this depends on Framework Dependent Executable (FDE) mode of deployment (which is also the default for FDD now in .NET Core 3). It's not relevant to Self Contained Deploment (SCD) as the published application will contain all the dependent runtime and is fixed to the specified target runtime version and platform.

This primarily is aimed at .NET Core. It might be possible to target .NET Framework and it may report the versions, but even if that works, it likely won't prompt for install.


