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

using System.Xml.Serialization;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher
{
    [XmlInclude(typeof(BasicAppTemplate))]
    [XmlInclude(typeof(CustomAppTemplate))]
    [XmlInclude(typeof(JavaAppTemplate))]
    [XmlInclude(typeof(SteamAppTemplate))]
    public abstract class AppTemplate
    {
        public abstract AppInfo Info { get; }

        [JsonIgnore]
        public bool CanConfigure = true;  

        public virtual bool Configure()
        {
            return false;
        }
    }
}
