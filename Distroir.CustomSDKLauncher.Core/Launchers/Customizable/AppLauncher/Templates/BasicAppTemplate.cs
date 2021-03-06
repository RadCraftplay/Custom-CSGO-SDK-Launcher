﻿/*
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

using System;
using System.Drawing;
using System.IO;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Basic;
using Distroir.CustomSDKLauncher.UI.Dialogs.AppLauncher;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class BasicAppTemplate : AppTemplate, IEquatable<BasicAppTemplate>
    {
        public SDKApplication Application { get; set; }

        public BasicAppTemplate()
        {
            Application = SDKApplication.None;
        }

        [JsonIgnore]
        public override AppInfo Info
        {
            get
            {
                var info = new AppInfo();

                if (Application != SDKApplication.None)
                    info = GetToolStartInfo(Application);

                info.DisplayText = GetDisplayText();
                info.Icon = GetIcon();

                return info;
            }
        }

        public override bool Configure()
        {
            var dialog = new BasicAppConfigurationDialog((SdkApplication)(int)Application);
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return false;

            Application = (SDKApplication)(int)dialog.SelectedApplication;

            return true;
        }

        private string GetDisplayText()
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

        private Image GetIcon()
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

        private AppInfo GetToolStartInfo(SDKApplication app)
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

        private string GetToolPath(SDKApplication app)
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
        
        public bool Equals(BasicAppTemplate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Application == other.Application;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BasicAppTemplate) obj);
        }

        public override int GetHashCode()
        {
            return (int) Application;
        }

        public static bool operator ==(BasicAppTemplate left, BasicAppTemplate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BasicAppTemplate left, BasicAppTemplate right)
        {
            return !Equals(left, right);
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
