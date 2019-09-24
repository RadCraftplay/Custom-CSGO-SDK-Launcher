using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class GameChecker
    {
        private readonly Game _gameToCheck;
        private readonly ToolChecker _toolChecker;

        public GameChecker(Game gameToCheck)
        {
            _gameToCheck = gameToCheck;
            _toolChecker = new ToolChecker(_gameToCheck.GameDir);
        }

        public bool IsValid()
        {
            return ValidateDirectories()
                && ValidateToolPaths();
        }

        private bool ValidateToolPaths()
        {
            return _toolChecker.CheckIfToolsExist();
        }

        private bool ValidateDirectories()
        {
            string gameInfoDirPath = Path.Combine(_gameToCheck.GameDir, _gameToCheck.GameinfoDirName);

            return Directory.Exists(_gameToCheck.GameDir)
                && Directory.Exists(gameInfoDirPath);
        }
    }
}
