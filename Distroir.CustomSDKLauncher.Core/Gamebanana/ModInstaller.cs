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
        /// <summary>
        /// Installer arguments
        /// </summary>
        string[] args;
        /// <summary>
        /// Mod informations
        /// </summary>
        ModInfo info;
        /// <summary>
        /// Name of zip file
        /// </summary>
        string fileName;
        /// <summary>
        /// List of failed entries
        /// </summary>
        List<string> failedEntries = new List<string>();
        /// <summary>
        /// If true, cancels installation
        /// </summary>
        bool cancel = false;
        /// <summary>
        /// What to do if we find duplicated filename
        /// </summary>
        DefaultDuplicateAction replaceAction = DefaultDuplicateAction.Ask;

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
            failedEntries = null;
        }

        /// <summary>
        /// Downloads and installs mod
        /// </summary>
        public bool ProcessMod()
        {
            //True if mod was succesfully downloaded and instaled
            bool success = false;

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
                success = InstallMod();
            }

            //Remove file after all operations
            File.Delete(fileName);

            return success;
        }

        /// <summary>
        /// Downloads mod
        /// </summary>
        bool DownloadMod()
        {
            var f = new Dialogs.ModDownloadDialog(info.Url, fileName);
            f.ShowDialog();
            return f.DialogResult == DialogResult.OK;
        }

        /// <summary>
        /// Installs mod
        /// </summary>
        bool InstallMod()
        {
            bool success;
            //Check if archive is zip
            ZipFile f = new ZipFile(fileName);
            //Get profile associated with game id
            Profile current = GetProfileAssociatedWithGameId(info.GameId);

            //Extract files
            success = ExtractFiles(f, current);
            //Free access to file
            f.Dispose();

            return success;
        }

        Profile GetProfileAssociatedWithGameId(string gameId)
        {
            //Load templates
            if (Managers.DataManagers.TemplateManager.Objects == null)
                Managers.DataManagers.TemplateManager.Load();

            //Look for template matching game id
            foreach (Template t in Managers.DataManagers.TemplateManager.Objects)
            {
                //If game id matches
                if (t.GameId == gameId) //Look for profile with matching game info directory
                    foreach (Profile p in Managers.DataManagers.ProfileManager.Objects)
                        if (p.GameinfoDirName == t.GameinfoDirName)
                            return p; //If profile matches criteria, return this profile
            }

            //No template/profile matched criteria
            //Throw an exception
            throw new UnknownGameIdException();
        }

        /// <summary>
        /// Extracts mod
        /// </summary>
        /// <param name="f">ZipFile to extract</param>
        /// <param name="p">Current profile</param>
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
                    //Get meta file info
                    MetaInfo mf = new MetaInfo();
                    mf.Destination = r.ReadLine();
                    mf.DirectoryInArchive = r.ReadLine();

                    //Extract all files matching meta info
                    foreach (ZipEntry entry in f.Entries)
                    {
                        //Try to extract entry
                        if (entry.FileName.StartsWith(mf.DirectoryInArchive))
                        {
                            TryExtractEntry(Path.Combine(p.GetGameinfoDirectory(), mf.Destination), mf.DirectoryInArchive, entry);
                        }

                        //Cancels installation
                        if (cancel)
                        {
                            break;
                        }
                    }
                }
            }

            //If there are failed entries
            //Display list of failed entries
            if (failedEntries.Count > 0)
            {
                //Generate message
                string message = "Entries failed to extract:";

                foreach (string entry in failedEntries)
                {
                    message += "\n" + entry;
                }

                //Display error message
                MessageBoxes.Error(message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Tries to extract entry
        /// </summary>
        /// <param name="destinationDir">Destination extract directory</param>
        /// <param name="directoryInArchive">Directory inside archive</param>
        /// <param name="e">Zip entry to extract</param>
        void TryExtractEntry(string destinationDir, string directoryInArchive, ZipEntry e)
        {
            try
            {
                //Tries to extract entry
                ExtractEntry(destinationDir, directoryInArchive, e);
            }
            catch
            {
                //If failed, adds entry to "failedEntries" list
                failedEntries.Add(e.FileName);
            }
        }

        /// <summary>
        /// Extracts entry
        /// </summary>
        /// <param name="destinationDir">Destination extract directory</param>
        /// <param name="directoryInArchive">Directory inside archive</param>
        /// <param name="e">Zip entry to extract</param>
        void ExtractEntry(string destinationDir, string directoryInArchive, ZipEntry e)
        {
            //string postfix = e.FileName.Substring(directoryInArchive.Length);
            //string filename = destinationDir + postfix;
            string entryname = GeneratePath(destinationDir, directoryInArchive, e);

            //Check if entry is directory
            if (e.IsDirectory)
            {
                Directory.CreateDirectory(entryname);
                return;
            }

            //Entry is a file
            //If file exists, skip entry
            if (File.Exists(entryname))
            {
                switch (replaceAction)
                {
                    case DefaultDuplicateAction.Ask:
                        //Create dialog
                        var dialog = new Dialogs.ReplaceFileDialog(entryname);

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (dialog.action == DefaultDuplicateAction.Replace)
                            {
                                File.Delete(entryname);
                                break;
                            }
                            if (dialog.action == DefaultDuplicateAction.Skip)
                            {
                                return;
                            }
                            else
                            {
                                replaceAction = dialog.action;

                                if (replaceAction == DefaultDuplicateAction.ReplaceAll)
                                {
                                    File.Delete(entryname);
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }

                        //Skip file by default
                        return;
                    case DefaultDuplicateAction.SkipAll:
                        return;
                    case DefaultDuplicateAction.ReplaceAll:
                        File.Delete(entryname);
                        break;
                }
            }

            //Extract file
            using (FileStream fs = new FileStream(entryname, FileMode.CreateNew))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //Extract file to memory
                    e.Extract(ms);
                    //Write file
                    byte[] file = ms.ToArray();
                    fs.Write(file, 0, file.Length);
                }
            }
        }

        /// <summary>
        /// Cuts root directory from entry path
        /// </summary>
        string CutPath(string root, string entryPath)
        {
            return entryPath.Substring(root.Length);
        }

        /// <summary>
        /// Generates name of output file
        /// </summary>
        string GeneratePath(string destinationDir, string directoryInArchive, ZipEntry e)
        {
            //Create file path relative to destination directory
            string filePath = CutPath(directoryInArchive, e.FileName).Replace('/', '\\');

            //Combine directory path and file path
            return filePath.StartsWith("\\") ? destinationDir + filePath : Path.Combine(destinationDir, filePath);
        }

        public enum DefaultDuplicateAction
        {
            Ask,
            Replace,
            ReplaceAll,
            Skip,
            SkipAll
        }
    }
}
