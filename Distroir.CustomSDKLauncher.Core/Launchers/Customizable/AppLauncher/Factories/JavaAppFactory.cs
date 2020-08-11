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
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
        
        public JavaApplication Application { get; private set; }
        
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

        public bool Configure()
        {
            var dialog = new JavaAppConfigurationDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Application = new JavaApplication(dialog.Info);
                return true;
            }

            return false;
        }
    }
}