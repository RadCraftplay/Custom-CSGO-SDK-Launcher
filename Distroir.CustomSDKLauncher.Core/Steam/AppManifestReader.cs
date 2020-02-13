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