using System;
using System.IO;
using System.Linq;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders
{
    public class PathJavaPathFinder : IJavaPathFinder
    {
        public string Path => "javaw";
        
        public bool CanGetPath()
        {
            var path = Environment.GetEnvironmentVariable("Path");
            var entries = path?.Split(';');
            if (entries == null)
                return false;
            
            var directories = entries.Where(Directory.Exists)
                .Select(x => new DirectoryInfo(x))
                .AsParallel();

            foreach (var directory in directories)
            {
                var firstValidFile = directory
                    .EnumerateFiles()
                    .First(x => x.Name == "javaw.exe");

                if (firstValidFile != null)
                    return true;
            }

            return false;
        }
    }
}