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

using System;
using System.Drawing;
using Distroir.CustomSDKLauncher.Core.Managers.ContentSerializers.Json;
using Newtonsoft.Json;
using Distroir.CustomSDKLauncher.Core.Utilities;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class SteamAppTemplate : AppTemplate, IEquatable<SteamAppTemplate>
    {
        public int AppId { get; private set; }
        public string Name { get; private set; }

        [JsonConverter(typeof(JsonImageConverter))]
        public Image Icon { get; private set; }

        public SteamAppTemplate()
        {
            AppId = -1;
            Name = "Steam application";
            Icon = Data.DefaultIcon;
        }

        public SteamAppTemplate(string name, int appId)
        {
            Name = name;
            AppId = appId;
            Icon = Data.DefaultIcon;
        }
        
        [JsonConstructor]
        public SteamAppTemplate(string name, int appId, Image icon)
        {
            AppId = appId;
            Name = name;
            Icon = icon;
        }
        
        [JsonIgnore]
        public override AppInfo Info =>
            new AppInfo()
            {
                UseCustomArguments = false,
                UseCustomWorkingDirectory = false,
                Path = "steam://run/" + AppId,
                DisplayText = Name,
                Icon = Icon
            };

        public override bool Configure()
        {
            var dialog = new Core.AppLauncher.Dialogs.SteamAppConfigurationDialog()
            {
                AppName = Name,
                AppId = AppId,
                AppIcon = Icon
            };
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!dialog.AppId.HasValue)
                    return false;
                
                AppId = dialog.AppId.Value;
                Name = dialog.AppName;
                Icon = dialog.AppIcon;
                
                return true;
            }

            return false;
        }
        
        public bool Equals(SteamAppTemplate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AppId == other.AppId && Name == other.Name &&
                   BitmapComparer.Compare((Bitmap) Icon, (Bitmap) other.Icon);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SteamAppTemplate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AppId;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Icon != null ? Icon.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(SteamAppTemplate left, SteamAppTemplate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SteamAppTemplate left, SteamAppTemplate right)
        {
            return !Equals(left, right);
        }
    }
}
