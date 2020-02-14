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
using System.Linq;
using Gameloop.Vdf;
using Gameloop.Vdf.Linq;

namespace Distroir.CustomSDKLauncher.Core.Steam
{
    public class AppManifestReader : IDisposable
    {
        private readonly TextReader _manifestFileReader;
        
        public AppManifestReader(string manifestFilename)
        {
            _manifestFileReader = new StreamReader(manifestFilename);
        }

        public string GetRelativeInstallDirectory()
        {
            var manifest = VdfConvert.Deserialize(_manifestFileReader.ReadToEnd());
            var children = manifest.Value.Children();

            return children.FirstOrDefault(x => x.Key == "installdir")?.Value?.ToString();
        }

        public Template GetGameTemplate()
        {
            var manifest = VdfConvert.Deserialize(_manifestFileReader.ReadToEnd());
            var dictionary = manifest.Value.Children()?
                .ToDictionary(x => x.Key, x => x.Value);

            return CreateGameTemplate(dictionary);
        }

        private Template CreateGameTemplate(Dictionary<string, VToken> manifestProperties)
        {
            return new Template()
            {
                Name = manifestProperties?["name"].ToString(),
                GameDirName = manifestProperties?["installdir"].ToString()
            };
        }

        public void Dispose()
        {
            _manifestFileReader?.Dispose();
        }
    }
}