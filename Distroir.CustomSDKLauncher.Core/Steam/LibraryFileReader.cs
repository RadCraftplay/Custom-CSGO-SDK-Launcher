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
using System.Collections.Generic;
using System.IO;
using Gameloop.Vdf;
using Gameloop.Vdf.Linq;

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

            foreach (var property in libraryDeserialized.Value.Children<VProperty>())
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