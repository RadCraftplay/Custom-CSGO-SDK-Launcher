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
        private readonly DirectoryChecker _directoryChecker;

        public GameChecker(Game gameToCheck)
        {
            _gameToCheck = gameToCheck;
            _toolChecker = new ToolChecker(_gameToCheck.GameDir);
            _directoryChecker = new DirectoryChecker(_gameToCheck);
        }

        public bool IsValid()
        {
            return ValidateDirectories()
                && ValidateToolPaths();
        }

        private bool ValidateToolPaths()
        {
            return _toolChecker.Validate();
        }

        private bool ValidateDirectories()
        {
            return _directoryChecker.Validate();
        }
    }
}
