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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Distroir.CustomSDKLauncher.Core.Utilities;
using System.IO;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana.Dialogs
{
    public partial class ModDownloadDialog : Form
    {
        WebClient c;
        string fileName;

        public ModDownloadDialog(string Url, string FileName)
        {
            InitializeComponent();
            fileName = FileName;

            Download(Url);
        }

        void Download(string url)
        {
            c = new WebClient();
            c.DownloadProgressChanged += DownloadProgressChanged;
            c.DownloadFileCompleted += DownloadProgressCompleted;

            c.DownloadFileAsync(new Uri(url), fileName);
        }

        private void DownloadProgressCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled)
                DialogResult = DialogResult.OK;
            Close();
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgressBar.Value = e.ProgressPercentage;
            downloadProgressLabel.Text = $"{e.ProgressPercentage}% ({FormatSize(e.BytesReceived)}/{FormatSize(e.TotalBytesToReceive)})";
        }

        string FormatSize(long Bytes)
        {
            if (Bytes > 1024)
            {
                if (Bytes > 1024 * 1024)
                    return Bytes / (1024 * 1024) + "Mb";

                return Bytes / 1024 + "kb";
            }
            else
                return Bytes + "b";
        }

        private void ModDownloadDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (c != null)
            {
                // Cancel all downloading operations
                c.CancelAsync();

                //Wait until WebClient cancel downloading
                //Probably isn't the best solution but that simply works
                while (c.IsBusy) { }
            }
        }
    }
}
