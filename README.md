# dotnet-version-check

![](https://github.com/tjmoore/dotnet-version-check/workflows/build/badge.svg)

Reports .NET runtime version information and/or triggers a prompt to install .NET Core runtime if applicable

## Usage

```
dotnet-version-check:
  Reports .NET runtime version information and/or triggers a prompt to install runtime if applicable

Usage:
  dotnet-version-check [options]

Options:
  --no-window    Don't display window, write version information to console
  --silent       Don't display window or write to console. Useful to only trigger .NET Core install if necessary
  --version      Display version information
```

This relies on .NET Core 3+ built-in support for prompting download and install of .NET Core runtime if not installed when running an executable. This only occurs with Windows GUI Executables.

This idea behind this is primarily for use when installing console or service applications that cannot self-prompt for install of the runtime. The solution here is by creating a WinExe executable targetting .NET Core 3 and running that during install, it should prompt for the missing runtime. This is as an alternative to scripting an installer to detect a compatible runtime globally installed which can be somewhat complex and the framework has built in support for this anyway.

The executabe need do nothing other than start and shut down, but it does have to be a WinExe target.

In this example it does a little more by providing a window showing the installed framework and/or reporting to console, but with a 'silent' option for use in an installer so it either does nothing or the user receives a prompt to install the runtime.

Note, this depends on Framework Dependent Executable (FDE) mode of deployment (which is also the default for FDD now in .NET Core 3). It's not relevant to Self Contained Deploment (SCD) as the published application will contain all the dependent runtime and is fixed to the specified target runtime version and platform.

This primarily is aimed at .NET Core. It might be possible to target .NET Framework and it may report the versions, but even if that works, it likely won't prompt for install.


