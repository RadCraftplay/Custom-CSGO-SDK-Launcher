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

        public AppInfo Info { get; private set; }

        public AppInfo GetInfo()
        {
            return Info;
        }

        public bool Configure()
        {
            var dialog = new CustomAppConfigurationDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Info = dialog.info;
                return true;
            }

            return false;
        }
    }
}