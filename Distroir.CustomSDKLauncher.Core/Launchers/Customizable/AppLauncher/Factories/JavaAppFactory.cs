using System;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Java;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public class JavaAppFactory : IAppInfoFactory
    {
        public JavaAppFactory(JavaApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
        
        public JavaApplication Application { get; }
        
        public AppInfo GetInfo()
        {
            return new AppInfo()
            {
                DisplayText = Application.Name,
                Icon = Application.Icon,
                Path = Application.JarFilePath,
                UseCustomArguments = true,
                Arguments = $"-jar {'"'}{Application.JarFilePath}{'"'}"
            };
        }
    }
}