using System.Collections.Generic;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class GameChecker
    {
        private readonly ToolChecker _toolChecker;
        private readonly DirectoryChecker _directoryChecker;

        public string[] ErrorMessages
        {
            get
            {
                List<string> errorMessages = new List<string>();

                if (!string.IsNullOrEmpty(_toolChecker.LastErrorMessage))
                    errorMessages.Add(_toolChecker.LastErrorMessage);
                if (!string.IsNullOrEmpty(_directoryChecker.LastErrorMessage))
                    errorMessages.Add(_directoryChecker.LastErrorMessage);

                return errorMessages.ToArray();
            }
        }

        public GameChecker(Game gameToCheck)
        {
            _toolChecker = new ToolChecker(gameToCheck.GameDir);
            _directoryChecker = new DirectoryChecker(gameToCheck);
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
