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