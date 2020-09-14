using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public class CustomAppFactory : IAppInfoFactory
    {
        public CustomAppFactory(AppInfo info)
        {
            Info = info;
        }

        public static CustomAppFactory Default => new CustomAppFactory(new AppInfo()
        {
            DisplayText = "Custom Application",
            Icon = Data.DefaultIcon
        });
        
        public AppInfo Info { get; }

        public AppInfo GetInfo()
        {
            return Info;
        }

        public IAppInfoFactory Configure()
        {
            var dialog = new CustomAppConfigurationDialog(Info);
            return dialog.ShowDialog() == DialogResult.OK ? new CustomAppFactory(dialog.Info) : this;
        }
    }
}