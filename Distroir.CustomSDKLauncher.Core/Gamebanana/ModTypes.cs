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
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana
{
    public class ModTypes
    {
        public static ModType Textures = new ModType()
        {
            //TODO: Add id
            TypeId = "textures",
            AssociatedDirectoryNames = new string[]
            {
                "materials"
            }/*,
            AssociatedExtensions = new string[]
            {
                "vmt",
                "vtf"
            }*/
        };

        public static ModType Models = new ModType()
        {
            //TODO: Add id
            TypeId = "models",
            AssociatedDirectoryNames = new string[]
            {
                "models",
                "materials"
            }/*,
            AssociatedExtensions = new string[]
            {
                "mdl",
                "phy",
                "vvd",
                "vtx"
            }*/
        };

        public static ModType Prefabs = new ModType()
        {
            //TODO: Add id
            TypeId = "prefabs",
            AssociatedDirectoryNames = new string[]
            {
                "prefabs"
            }/*,
            AssociatedExtensions = new string[]
            {
                "vmf"
            }*/
        };

        public static ModType Maps = new ModType()
        {
            //TODO: Add id
            TypeId = "castaways"/*,
            AssociatedExtensions = new string[]
            {
                "vmf"
            }*/
        };
    }
}