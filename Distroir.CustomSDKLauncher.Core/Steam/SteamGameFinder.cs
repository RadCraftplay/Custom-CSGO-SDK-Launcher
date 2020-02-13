﻿using System.Collections.Generic;
using System.IO;
using Distroir.CustomSDKLauncher.Core.Managers;
using Microsoft.Win32;

namespace Distroir.CustomSDKLauncher.Core.Steam
{
    public static class SteamGameFinder
    {
        public static IEnumerable<Game> GetSupportedSteamGames()
        {
            var libraryFolders = GetLibraryFolders();
            
            if (DataManagers.TemplateManager.Objects.Count == 0)
                if (!DataManagers.TemplateManager.TryLoad())
                    yield break;

            var templates = DataManagers.TemplateManager.Objects;

            foreach (var libraryFolder in libraryFolders)
            {
                var manifests = GetAppManifestsInLibrary(libraryFolder);
                foreach (var manifest in manifests) 
                {
                    using (var reader = new AppManifestReader(manifest))
                    {
                        var template = reader.GetGameTemplate();
                        foreach (var presetTemplate in templates)
                        {
                            if (presetTemplate == template)
                            {
                                var gameDirPath = Path.Combine(libraryFolder, "steamapps", "common",
                                    presetTemplate.GameDirName)
                                    .Replace('/', '\\');
                                yield return presetTemplate.ToGame(gameDirPath);
                            }
                        }
                    }
                }
            }
        }

        public static string GetSteamDirectory()
        {
            var steamKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default)
                .OpenSubKey("Software\\Valve\\Steam");
            
            return steamKey?.GetValue("SteamPath").ToString();
        }

        public static IEnumerable<string> GetLibraryFolders()
        {
            var steamDirectory = GetSteamDirectory();
            var libraryFile = Path.Combine(steamDirectory, "steamapps", "libraryfolders.vdf");
            
            yield return steamDirectory;

            using (var reader = new LibraryFileReader(libraryFile))
                foreach (var libraryFolder in reader.GetLibraryFolders())
                    yield return libraryFolder;
        }

        private static IEnumerable<string> GetAppManifestsInLibrary(string libraryDirectory)
        {
            var appsDirectory = Path.Combine(libraryDirectory, "steamapps");
            var dirInfo = new DirectoryInfo(appsDirectory);

            foreach (var fileInfo in dirInfo.EnumerateFiles())
                if (fileInfo.Extension.ToLower() == ".acf")
                    yield return fileInfo.FullName;
        }
    }
}