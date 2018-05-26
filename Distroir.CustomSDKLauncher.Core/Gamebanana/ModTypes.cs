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