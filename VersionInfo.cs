using System;
using System.Reflection;
using System.Runtime.Versioning;

namespace DotNetVersionCheck
{
    public class VersionInfo
    {
        private string _targetFramework;
        private string _runtimeVersion;

        public string TargetFramework
        {
            get
            { 
                if (_targetFramework == null)
                {
                    _targetFramework = Assembly
                        .GetEntryAssembly()?
                        .GetCustomAttribute<TargetFrameworkAttribute>()?
                        .FrameworkName;
                }

                return _targetFramework;
            }
        }
        public string RuntimeVersion
        {
            get
            {
                if (_runtimeVersion == null)
                    _runtimeVersion = Environment.Version.ToString();

                return _runtimeVersion;
            }
        }
    }
}
