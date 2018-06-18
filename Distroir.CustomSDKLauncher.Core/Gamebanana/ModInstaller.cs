﻿/*
Custom SDK Launcher
Copyright (C) 2017-2018 Distroir

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Utilities;
using Distroir.CustomSDKLauncher.Core.Gamebanana.Exceptions;
using Ionic.Zip;
using System.Xml.Serialization;

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
            info = null;
            fileName = null;
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
                return InstallMod();
            }

            return false;
        }

        bool DownloadMod()
        {
            var f = new Dialogs.ModDownloadDialog(info.Url, fileName);
            f.ShowDialog();
            return f.DialogResult == DialogResult.OK;
        }

        bool InstallMod()
        {
            //Check if archive is zip
            //Look for files and folders associated with specific mod type

            ZipFile f = new ZipFile(fileName);
            ModType modType = ModType.FromId(info.CategoryId);
            Profile current;

            //Get current profiles
            //TODO: Automatically try to find game dir based on directory id
            if (!Utils.TryGetSelectedProfile(out current))
                return false;

            //Extract files
            return ExtractFiles(f, current);
        }

        bool ExtractFiles(ZipFile f, Profile p)
        {
            //Check if archive contains meta file
            if (!f.ContainsEntry("meta/meta"))
            {
                //File does not exist, throw an exception
                throw new NoMetaFileException();
            }

            //Get meta file inside archive
            ZipEntry meta = f.Entries.FirstOrDefault(e => e.FileName == "meta/meta");

            using (MemoryStream ms = new MemoryStream())
            {
                //Extract meta file to memory stream
                meta.Extract(ms);
                //Reset reader position to zero
                ms.Seek(0, SeekOrigin.Begin);

                using (TextReader r = new StreamReader(ms))
                {
                    //Check if meta file was loaded correctly
                    //if (!metaReader.TryLoad())
                    //{
                    //    //If there was an error
                    //    //Throw an exception
                    //    throw new InvalidMetaFileException();
                    //}

                    //Get meta file info
                    MetaInfo mf = new MetaInfo();
                    mf.Destination = r.ReadLine();
                    mf.DirectoryInArchive = r.ReadLine();

                    //Extract all files matching meta info
                    foreach (ZipEntry entry in f.Entries)
                    {
                        if (entry.FileName.StartsWith(mf.DirectoryInArchive))
                        {
                            entry.Extract(PathFormatter.Format(mf.Destination), ExtractExistingFileAction.DoNotOverwrite);
                        }  
                    }
                }
            }

            return true;

        }
    }
}
