using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Utilities;
using Ionic.Zip;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana
{
    public class ModInstaller : IDisposable
    {
        string[] args;
        ModInfo info;
        string fileName;

        public ModInstaller(string[] Args)
        {
            args = Args;
            fileName = $"{Path.GetTempPath()}\\CSDKL_{DateSerializer.SerializeDateAndTime(DateTime.Now)}_mod.tmp";
        }

        public void Dispose()
        {
            args = null;
        }

        /// <summary>
        /// Downloads and installs mod
        /// </summary>
        public bool ProcessMod()
        {
            //Get mod info
            info = ArgsParser.Parse(args);

            if (info == null)
            {
                return false;
            }

            //Try to download mod
            if (DownloadMod())
            {
                //Try to install mod
                InstallMod();
                return true;
            }

            return false;
        }

        bool InstallMod()
        {
            //Check if archive is zip
            //Look for files and folders associated with specific mod type

            ZipFile f = new ZipFile(fileName);
            ModType modType = ModType.FromId(info.CategoryId);
            Profile current;

            //Get current profiles
            if (!Utils.TryGetSelectedProfile(out current))
                return false;

            foreach (ZipEntry e in f.Entries)
            {
                foreach (string directory in modType.AssociatedDirectoryNames)
                {
                    if (e.FileName.StartsWith(directory))
                        e.Extract(current.GetGameinfoDirectory(), ExtractExistingFileAction.OverwriteSilently);
                }
            }

            return true;
        }

        bool DownloadMod()
        {
            var f = new Dialogs.ModDownloadDialog(info.Url, fileName);
            f.ShowDialog();
            return f.DialogResult == DialogResult.OK;
        }
    }
}
