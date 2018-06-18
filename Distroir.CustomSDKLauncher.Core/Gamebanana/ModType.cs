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
using System.Reflection;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana
{
    public class ModType
    {
        public string TypeId;
        public string[] AssociatedDirectoryNames;

        public static ModType FromId(string id)
        {
            //Get static members of ModTypes class
            FieldInfo[] ModTypes = typeof(ModTypes).GetFields();

            //Look for mod type with specified id
            foreach (FieldInfo i in ModTypes)
            {
                //Get mod type
                ModType t = (ModType)i.GetValue(null);

                if (t.TypeId == id)
                    return t;
            }

            return null;
        }

        public static ModType[] GetModTypes()
        {
            //Get static members of ModTypes class
            FieldInfo[] fields = typeof(ModTypes).GetFields();

            //Create ModTyoe array
            ModType[] modtypes = new ModType[fields.Length];

            //Get mod types from fields
            for (int i = 0; i < modtypes.Length; i++)
            {
                modtypes[i] = (ModType)fields[i].GetValue(null);
            }

            //Return ModType array
            return modtypes;
        }
    }
}