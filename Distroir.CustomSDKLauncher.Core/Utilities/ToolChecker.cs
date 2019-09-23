using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    /// <summary>
    /// Used in first launch dialog to check if SDK tools are installed
    /// </summary>
    public class ToolChecker
    {
        public string LastErrorMessage { get; private set; }

        private readonly Dictionary<string, string> _toolset;
        private string _gamePath;

        public ToolChecker(string gamePath)
        {
            _toolset = GetToolset();
            _gamePath = gamePath;
        }

        public bool CheckIfToolsExist()
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

                    errorMessageBuilder.AppendFormat("{0}{1}{0} - {0}{2}{0}", '"', pair.Key, pair.Value);
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
            toolset.Add("Face Poser", "bin\\hlmv.exe");
            return toolset;
        }
    }
}
