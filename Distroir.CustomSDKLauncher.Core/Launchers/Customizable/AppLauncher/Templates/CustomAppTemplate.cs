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
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class CustomAppTemplate : AppTemplate, IEquatable<CustomAppTemplate>
    {
        private AppInfo _info;
        public override AppInfo Info => _info;


        public CustomAppTemplate()
        {
            _info = new AppInfo()
            {
                Icon = Data.DefaultIcon,
                DisplayText = "Custom application"
            };
        }

        [JsonConstructor]
        public CustomAppTemplate(AppInfo info)
        {
            _info = info;
        }

        public override bool Configure()
        {
            var d = new CustomAppConfigurationDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                if (d.info != null)
                {
                    _info = d.info;
                    return true;
                }
            }

            return false;
        }
        
        public bool Equals(CustomAppTemplate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_info, other._info);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CustomAppTemplate) obj);
        }

        public override int GetHashCode()
        {
            return (_info != null ? _info.GetHashCode() : 0);
        }

        public static bool operator ==(CustomAppTemplate left, CustomAppTemplate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomAppTemplate left, CustomAppTemplate right)
        {
            return !Equals(left, right);
        }
    }
}
