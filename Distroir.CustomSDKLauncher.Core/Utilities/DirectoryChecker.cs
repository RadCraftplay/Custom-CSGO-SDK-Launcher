using System.IO;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class DirectoryChecker : IChecker
    {
        public string LastErrorMessage { get; private set; }
        private readonly Game _gameToCheck;

        public DirectoryChecker(Game toCheck)
        {
            _gameToCheck = toCheck;
        }

        public bool Validate()
        {
            string gameInfoDirPath = Path.Combine(_gameToCheck.GameDir, _gameToCheck.GameinfoDirName);

            return Directory.Exists(_gameToCheck.GameDir)
                && Directory.Exists(gameInfoDirPath);
        }
    }
}
