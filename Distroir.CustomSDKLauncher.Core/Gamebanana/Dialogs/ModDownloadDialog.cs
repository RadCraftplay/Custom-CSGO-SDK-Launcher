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

        public ModDownloadDialog(string Url)
        {
            InitializeComponent();
            FormClosing += ModDownloadDialog_FormClosing;

            Download(Url);
        }

        private void ModDownloadDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            c.CancelAsync();
        }

        void Download(string url)
        {
            c = new WebClient();
            c.DownloadProgressChanged += DownloadProgressChanged;
            c.DownloadFileCompleted += DownloadProgressCompleted;

            c.DownloadFileAsync(new Uri(url), CombineFileName());
        }

        private void DownloadProgressCompleted(object sender, AsyncCompletedEventArgs e)
        {
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

        string CombineFileName()
        {
            return $"{Path.GetTempPath()}\\CSDKL_{DateSerializer.SerializeDateAndTime(DateTime.Now)}_mod.tmp";
        }
    }
}
