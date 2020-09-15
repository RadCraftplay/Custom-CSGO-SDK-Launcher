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
using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class JavaAppTemplate : AppTemplate, IEquatable<JavaAppTemplate>
    {
        public override AppInfo Info => _info;

        private AppInfo _info;

        public JavaAppTemplate()
        {
            _info = new AppInfo()
            {
                Icon = Data.DefaultIcon,
                DisplayText = "Java application"
            };
        }

        [JsonConstructor]
        public JavaAppTemplate(AppInfo info)
        {
            _info = info;
        }

        public override bool Configure()
        {
            var v = new JavaAppConfigurationDialog();
            if (v.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _info = new JavaAppFactory(v.Application).GetInfo();
                return true;
            }

            return false;
        }
        
        public bool Equals(JavaAppTemplate other)
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
            return Equals((JavaAppTemplate) obj);
        }

        public override int GetHashCode()
        {
            return (_info != null ? _info.GetHashCode() : 0);
        }

        public static bool operator ==(JavaAppTemplate left, JavaAppTemplate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(JavaAppTemplate left, JavaAppTemplate right)
        {
            return !Equals(left, right);
        }
    }
}
