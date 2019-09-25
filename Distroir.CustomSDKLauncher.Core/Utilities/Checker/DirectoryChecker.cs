using System.IO;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities.Checker
{
    class DirectoryChecker : IChecker
    {
        public string LastErrorMessage { get; private set; }
        private readonly Game _gameToCheck;

        public DirectoryChecker(Game toCheck)
        {
            _gameToCheck = toCheck;
        }

        public bool Validate()
        {
            bool valid = true;
            StringBuilder errorMessageBuilder = new StringBuilder();

            string gameInfoDirPath = Path.Combine(_gameToCheck.GameDir, _gameToCheck.GameinfoDirName);

            if (!Directory.Exists(_gameToCheck.GameDir))
            {
                LogMissingDirectory(errorMessageBuilder, _gameToCheck.GameDir);
                valid = false;
            }

            if (!Directory.Exists(gameInfoDirPath))
            {
                LogMissingDirectory(errorMessageBuilder, gameInfoDirPath);
                valid = false;
            }

            LastErrorMessage = errorMessageBuilder?.ToString();
            return valid;
        }

        private void LogMissingDirectory(StringBuilder sb, string path)
        {
            if (sb.Length == 0)
            {
                sb.AppendLine("The following directories were not found:");
            }

            sb.AppendFormat("{0}{1}{0}\n", '"', path);
        }
    }
}
