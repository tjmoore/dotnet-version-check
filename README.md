# dotnet-version-check

![](https://github.com/tjmoore/dotnet-version-check/workflows/build/badge.svg)

Reports .NET runtime version information and/or triggers a prompt to install .NET Core runtime if applicable


This relies on .NET Core 3+ built-in support for prompting download and install of .NET Core runtime if not installed when running an executable. This only occurs with Windows GUI Executables.

The idea is this is a simple executable that can be run during an installer, letting the .NET Core Windows executable bootstrap handle runtime version checking, download and installation. This is useful where the actual .NET Core application being installed is a console or service application which won't generate a prompt and in the case of a service cannot prompt the user without desktop interactivity.

Additionally, this application can produce a window showing the runtime and target information or send that information to a console.

An alternative is to go checking install locations and/or registry as described here:

https://github.com/dotnet/designs/blob/master/accepted/install-locations.md

However this is somewhat complicated, especially if you want to depend on a compatible install being present, e.g. same version or newer minor & patch version, so that you can pick up latest fixes. This process is built into .NET Core 3 Windows GUI executables anyway so it would seem to make sense to use that functionality.

Note, this depends on Framework Dependent Executable (FDE) mode of deployment (which is also the default for FDD now in .NET Core 3). It's not relevant to Self Contained Deploment (SCD) as the published application will contain all the dependent runtime and is fixed to the specified target runtime version and platform.

This primarily is aimed at .NET Core. It might be possible to target .NET Framework and it may report the versions, but even if that works, it likely won't prompt for install.

The code provided here could act as an example to integrate into other applications, although the actual prompt for install functionality only really requires targetting WinExe output type.

## Usage

```
dotnet-version-check:
  Reports .NET runtime version information and triggers a prompt to install runtime if applicable

Usage:
  dotnet-version-check [options]

Options:
  --no-window    Don't display window, write version information to console
  --silent       Don't display window or write to console. Useful to only trigger .NET Core install if necessary
  --version      Display version information
```
