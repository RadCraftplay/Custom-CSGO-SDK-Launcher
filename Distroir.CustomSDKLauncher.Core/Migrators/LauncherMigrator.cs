using System.Windows.Forms;
using Distroir.Configuration;

namespace Distroir.CustomSDKLauncher.Core.Migrators
{
    public class LauncherMigrator : IMigrator
    {
        public bool RequiresMigration()
        {
            return Config.HasVariable("UseNewLauncher");
        }

        public void Migrate()
        {
            var useNewLauncher = Config.ReadInt("UseNewLauncher");
            
            var dialogResult = MessageBox.Show("A new launcher has been added. Would you like to try it out?" +
                                               "\n\nYou can always switch launcher in: Settings > App Launcher > Launcher",
                "Custom SDK Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            
            Config.AddVariable("LauncherType", dialogResult == DialogResult.Yes ? 2 : useNewLauncher);
            Config.RemoveVariable("UseNewLauncher");
        }
    }
}