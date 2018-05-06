using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana
{
    public class ModInstaller : IDisposable
    {
        string[] args;
        ModInfo info;

        public ModInstaller(string[] Args)
        {
            args = Args;
        }
        public void Dispose()
        {
            args = null;
        }

        public void ProcessMod()
        {
            //Get mod info
            info = ArgsParser.Parse(args);
            //Try to donload mod
            if (DownloadMod())
            {
                //Try to install mod
                InstallMod();
            }
        }

        bool InstallMod()
        {
            //Check if archive is zip
            //Look for files and folders associated with specific mod type
            throw new NotImplementedException();
        }

        public bool DownloadMod()
        {
            var f = new Dialogs.ModDownloadDialog(info.Url);
            f.ShowDialog();
            return f.DialogResult == DialogResult.OK;
        }
    }
}
