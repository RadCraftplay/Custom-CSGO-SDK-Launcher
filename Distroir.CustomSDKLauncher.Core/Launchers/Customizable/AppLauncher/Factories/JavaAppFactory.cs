using System;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Java;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public class JavaAppFactory : IAppInfoFactory
    {
        public JavaAppFactory(JavaApplication application)
        {
            Application = application;
        }
        
        public static JavaAppFactory Default => new JavaAppFactory(new JavaApplication(
            "Java Application", 
            String.Empty, 
            String.Empty, 
            Data.DefaultIcon));
        
        public JavaApplication Application { get; }
        
        public AppInfo GetInfo()
        {
            return new AppInfo()
            {
                DisplayText = Application.Name,
                Icon = Application.Icon,
                Path = Application.JavaExecutablePath,
                UseCustomArguments = true,
                Arguments = $"-jar {'"'}{Application.JarFilePath}{'"'}"
            };
        }

        public IAppInfoFactory Configure()
        {
            var dialog = new JavaAppConfigurationDialog();
            return dialog.ShowDialog() == DialogResult.OK ? new JavaAppFactory(new JavaApplication(dialog.Info)) : this;
        }
    }
}