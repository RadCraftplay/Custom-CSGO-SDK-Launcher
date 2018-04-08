/*
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
using Distroir.CustomSDKLauncher.Core.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Utilities;

namespace Distroir.CustomSDKLauncher.Core.Backups
{
    public class BackupManager : IDisposable
    {
        /// <summary>
        /// Stream used to read/save stream
        /// </summary>
        FileStream Stream;
        /// <summary>
        /// Directory where backup will be restored to
        /// </summary>
        string Destination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Custom SDK Launcher");

        public BackupManager(string filename)
        {
            //Create stream
            Stream = new FileStream(filename, FileMode.OpenOrCreate);
        }

        /// <summary>
        /// Creates backup
        /// </summary>
        public void Backup()
        {
            //List of files, that will be backed up
            List<string> FileNames = new List<string>()
                {
                    Configuration.Config.destination,
                    ProfileManager.ProfileListFilename,
                    AppManager.AppListFilename
                };

            //Create entries
            List<BackupEntry> entries = CreateEntries(FileNames);
            //Calculate offsets of files
            CalculateOffsets(entries);
            //Write backup
            WriteBackup(entries);
        }

        /// <summary>
        /// Restores backup from file
        /// </summary>
        public void Restore()
        {
            //Restore all files
            RestoreBackup();
        }

        #region Backing up

        /// <summary>
        /// Calculates offsets of files
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        void CalculateOffsets(List<BackupEntry> entries)
        {
            //Calculate start offset
            int startOffset = 16;

            foreach (BackupEntry e in entries)
            {
                //LengthOfString    1 byte
                //FileName          ? byte(s) (Depends on LengthOfString)
                //Offset            4 bytes
                //Length            4 bytes

                startOffset += 9;
                startOffset += e.FileName.Length;
            }

            //Calculate offsets of files
            foreach (BackupEntry e in entries)
            {
                e.Offset = startOffset;
                startOffset += e.Length;
            }
        }

        /// <summary>
        /// Creates entries
        /// </summary>
        /// <param name="FileNames">Names of files to backup</param>
        /// <returns></returns>
        List<BackupEntry> CreateEntries(List<string> FileNames)
        {
            List<BackupEntry> entries = new List<BackupEntry>();

            //Create entries
            foreach (string filename in FileNames)
            {
                //Get informations about file
                FileInfo f = new FileInfo(filename);
                BackupEntry e = new BackupEntry();
                //Set values
                e.FileName = f.Name;
                e.FullName = f.FullName;
                e.Length = (int)f.Length;

                //Add entry
                entries.Add(e);
            }

            return entries;
        }

        /// <summary>
        /// Writes backup
        /// </summary>
        /// <param name="entries">List of entries</param>
        void WriteBackup(List<BackupEntry> entries)
        {
            //Get binaryWriter
            BinaryWriter w = new BinaryWriter(Stream);

            //Write header
            w.Write(0);                 //Version
            w.Write(0);                 //Reserved
            w.Write(0);                 //Reserved
            w.Write(entries.Count);     //Count of entries

            //Write all entries
            foreach (BackupEntry e in entries)
            {
                WriteEntry(e, w);
            }

            //Write all files
            foreach (BackupEntry e in entries)
            {
                WriteFile(e, w);
            }

            //Flush stream
            w.Flush();

            //Dispose stream
            w.Dispose();
        }

        /// <summary>
        /// Writes entry
        /// </summary>
        /// <param name="e">Entry to write</param>
        /// <param name="w">Stream</param>
        void WriteEntry(BackupEntry e, BinaryWriter w)
        {
            w.Write(e.FileName);
            w.Write(e.Length);
            w.Write(e.Offset);
        }

        /// <summary>
        /// Writes file
        /// </summary>
        /// <param name="e">Entry containing informations about file</param>
        /// <param name="w">Stream</param>
        void WriteFile(BackupEntry e, BinaryWriter w)
        {
            FileStream s = new FileStream(e.FullName, FileMode.Open);

            byte[] File = new byte[s.Length];

            //Get file content
            for (int i = 0; i < s.Length; i++)
            {
                //Read byte
                int b = s.ReadByte();

                //If end of stream, break loop
                if (b == -1)
                    break;

                //Add byte
                File[i] = (byte)b;
            }

            //Write file
            foreach (byte b in File)
            {
                w.Write(b);
            }

            //Close and dispose stream
            s.Close();
            s.Dispose();
        }

        #endregion

        #region Restoring

        void RestoreBackup()
        {
            BinaryReader r = new BinaryReader(Stream);
            BackupEntry[] entries;

            //Read header
            int version = r.ReadInt32();        //File version
            r.ReadInt32();  //Reserved
            r.ReadInt32();  //Reserved
            int countOfEntries = r.ReadInt32(); //Count of BackupEntries

            entries = new BackupEntry[countOfEntries];

            //Read entries
            for (int i = 0; i < countOfEntries; i++)
            {
                entries[i] = ReadEntry(r);
            }

            //Read files
            if (version == 0)
            {
                foreach (BackupEntry e in entries)
                {
                    RestoreFile(r, e, Destination);
                }
            }
        }

        BackupEntry ReadEntry(BinaryReader r)
        {
            //Read entry
            BackupEntry entry = new BackupEntry();
            entry.FileName = r.ReadString();
            entry.Length = r.ReadInt32();
            entry.Offset = r.ReadInt32();

            //Return entry
            return entry;
        }

        /// <summary>
        /// Restores file from backup
        /// </summary>
        /// <param name="r">BinaryReader of backup file</param>
        /// <param name="e">BackupEntry used to get informations about file</param>
        /// <param name="directory">Destination directory of file</param>
        void RestoreFile(BinaryReader r, BackupEntry e, string directory)
        {
            string filename = Path.Combine(directory, e.FileName);

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    //Set offset [Skipped]
                    //Reason: Unnecessary
                    //r.BaseStream.Position = e.Offset;

                    //Read bytes
                    byte[] data = r.ReadBytes(e.Length);

                    //Write data
                    foreach (byte b in data)
                    {
                        w.Write(b);
                    }
                }
            }
        }

        #endregion

        public void Dispose()
        {
            Stream.Close();
            Stream = null;
        }
    }
}
