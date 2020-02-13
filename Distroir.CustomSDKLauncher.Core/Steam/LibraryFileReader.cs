using System;
using System.Collections.Generic;
using System.IO;
using Gameloop.Vdf;

namespace Distroir.CustomSDKLauncher.Core.Steam
{
    public class LibraryFileReader : IDisposable
    {
        private readonly TextReader _libraryListFileReader;

        public LibraryFileReader(string libraryListFileName)
        {
            _libraryListFileReader = new StreamReader(libraryListFileName);
        }

        public IEnumerable<string> GetLibraryFolders()
        {
            var currentIndex = 1;
            var libraryDeserialized = VdfConvert.Deserialize(_libraryListFileReader.ReadToEnd());

            foreach (var property in libraryDeserialized.Value.Children())
            {
                if (property.Key == currentIndex.ToString())
                {
                    yield return property.Value.ToString();
                    currentIndex++;
                }
            }
        }

        public void Dispose()
        {
            _libraryListFileReader?.Dispose();
        }
    }
}