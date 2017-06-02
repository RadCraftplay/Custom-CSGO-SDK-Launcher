using Distroir.CustomSDKLauncher.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher
{
    static class Program
    {
        /// <summary>
        /// Entry point of an application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
