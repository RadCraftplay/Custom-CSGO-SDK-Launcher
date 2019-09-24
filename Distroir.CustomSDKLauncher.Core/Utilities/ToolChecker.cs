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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    /// <summary>
    /// Used in first launch dialog to check if SDK tools are installed
    /// </summary>
    public class ToolChecker : IChecker
    {
        public string LastErrorMessage { get; private set; }

        private readonly Dictionary<string, string> _toolset;
        private string _gamePath;

        public ToolChecker(string gamePath)
        {
            _toolset = GetToolset();
            _gamePath = gamePath;
        }

        public bool Validate()
        {
            bool error = false;
            StringBuilder errorMessageBuilder = new StringBuilder();

            foreach (var pair in _toolset)
            {
                string fullToolPath = GetFullToolPath(pair.Value);

                if (!File.Exists(fullToolPath))
                {
                    if (error == false)
                    {
                        error = true;
                        errorMessageBuilder.AppendLine("The following tools were not found:");
                    }

                    errorMessageBuilder.AppendFormat("{0}{1}{0} - {0}{2}{0}", '"', pair.Key, fullToolPath);
                    errorMessageBuilder.AppendLine();
                }
            }

            if (error)
                LastErrorMessage = errorMessageBuilder.ToString();

            return !error;
        }

        private string GetFullToolPath(string relativeToolPath)
        {
            return Path.Combine(_gamePath, relativeToolPath);
        }

        private Dictionary<string, string> GetToolset()
        {
            Dictionary<string, string> toolset = new Dictionary<string, string>();
            toolset.Add("Hammer World Editor", "bin\\hammer.exe");
            toolset.Add("Half-Life Model Viewer", "bin\\hlmv.exe");
            toolset.Add("Face Poser", "bin\\hlfaceposer.exe");
            return toolset;
        }
    }
}
