/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

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

using System.Drawing;
using System.IO;
using Distroir.CustomSDKLauncher.UI.Dialogs.AppLauncher;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class BasicAppTemplate : AppTemplate
    {
        public SDKApplication Application { get; set; } = SDKApplication.None;

        public BasicAppTemplate()
        {
            UpdateInfo();
        }

        public override bool Configure()
        {
            var dialog = new BasicAppConfigurationDialog(Application);
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return false;

            Application = dialog.SelectedApplication;
            UpdateInfo();

            return true;
        }

        void UpdateInfo()
        {
            Info = new AppInfo();

            if (Application != SDKApplication.None)
                Info = GetToolStartInfo(Application);

            Info.DisplayText = GetDisplayText();
            Info.Icon = GetIcon();
        }

        public void GenerateDefaultConfig(SDKApplication app)
        {
            Application = app;

            Info = GetToolStartInfo(Application);
            Info.DisplayText = GetDisplayText();
            Info.Icon = GetIcon();
        }

        public string GetDisplayText()
        {
            switch (Application)
            {
                case SDKApplication.Hammer:
                    return "Hammer World Editor";
                case SDKApplication.HLMV:
                    return "Model Viewer";
                case SDKApplication.FacePoser:
                    return "Face Poser";
                default:
                    return "Source SDK application";
            }
        }

        public Image GetIcon()
        {
            switch (Application)
            {
                case SDKApplication.HLMV:
                    return Data.ModelViewerIcon;
                case SDKApplication.FacePoser:
                    return Data.FacePoserIcon;
                default:
                    return Data.HammerIcon;
            }
        }

        AppInfo GetToolStartInfo(SDKApplication app)
        {
            AppInfo info = new AppInfo();
            info.Path = GetToolPath(app);

            info.UseCustomWorkingDirectory = true;
            info.CustomWorkingDirectory = Path.Combine("{GameDir}", "{GameinfoDir}");

            info.UseCustomArguments = true;
            if (app != SDKApplication.HLMV)
            {
                info.Arguments = "-nop4 ";
            }
            info.Arguments += string.Format("-game {0}{1}{0}", '"', Path.Combine("{GameDir}", "{GameinfoDir}"));

            return info;
        }

        string GetToolPath(SDKApplication app)
        {
            switch (app)
            {
                case SDKApplication.FacePoser:
                    return Path.Combine("{GameBinDir}", "hlfaceposer.exe");
                case SDKApplication.HLMV:
                    return Path.Combine("{GameBinDir}", "hlmv.exe");
                default:
                    return Path.Combine("{GameBinDir}", "hammer.exe");
            }
        }
    }

    /// <summary>
    /// As the name suggests
    /// </summary>
    public enum SDKApplication
    {
        /// <summary>
        /// Hammer world editor
        /// </summary>
        Hammer,
        /// <summary>
        /// Model viewer
        /// </summary>
        HLMV,
        /// <summary>
        /// Face poser
        /// </summary>
        FacePoser,
        None
    }
}
