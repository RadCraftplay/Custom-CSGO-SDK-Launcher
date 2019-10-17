/*
Custom SDK Launcher
Copyright (C) 2017-2019 Distroir

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
using System.Diagnostics;
using System.IO;
using Distroir.CustomSDKLauncher.Core.Launchers.View;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Apps
{
    public class StandardApp : IApp
    {
        private readonly StandardSdkApplication _application;

        public IDisplayableItem DisplayableItem => new StandardDisplayableItem(_application);

        public StandardApp(StandardSdkApplication application)
        {
            _application = application;
        }

        public void Launch(Game associatedGame)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = GetFullToolPath(associatedGame, _application),
                Arguments = GetToolArguments(associatedGame, _application),
                WorkingDirectory = associatedGame.GetBinDirectory()
            };

            Process.Start(startInfo);
        }

        private string GetFullToolPath(Game associatedGame, StandardSdkApplication application)
        {
            return Path.Combine(associatedGame.GameDir, "bin", GetToolExecutableName(application));
        }

        private string GetToolExecutableName(StandardSdkApplication application)
        {
            switch (application)
            {
                case StandardSdkApplication.Hammer:
                    return "hammer.exe";
                case StandardSdkApplication.HLMV:
                    return "hlmv.exe";
                case StandardSdkApplication.FacePoser:
                    return "hlfaceposer.exe";
                default:
                    throw new InvalidDataException("Parameter named 'application' has invalid value");
            }
        }

        private string GetToolArguments(Game associatedGame, StandardSdkApplication application)
        {
            string arguments = string.Empty;

            switch (application)
            {
                case StandardSdkApplication.Hammer:
                case StandardSdkApplication.FacePoser:
                    arguments += "-nop4 ";
                    break;
            }

            arguments += string.Format("-game {0}{1}{0}", '"', associatedGame.GetGameinfoDirectory());
            return arguments;
        }
    }
}
