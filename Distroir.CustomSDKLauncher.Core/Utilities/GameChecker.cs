namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class GameChecker
    {
        private readonly ToolChecker _toolChecker;
        private readonly DirectoryChecker _directoryChecker;

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
