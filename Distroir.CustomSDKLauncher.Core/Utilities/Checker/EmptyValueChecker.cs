namespace Distroir.CustomSDKLauncher.Core.Utilities.Checker
{
    class EmptyValueChecker : IChecker
    {
        public string LastErrorMessage { get; private set; }
        private Game _gameToCheck;

        public EmptyValueChecker(Game toCheck)
        {
            _gameToCheck = toCheck;
        }

        public bool Validate()
        {
            bool invalid = string.IsNullOrWhiteSpace(_gameToCheck.GameDir)
                        && string.IsNullOrWhiteSpace(_gameToCheck.GameinfoDirName)
                        && string.IsNullOrWhiteSpace(_gameToCheck.Name);

            if (invalid)
                LastErrorMessage = "One or more fields are empty";

            return !invalid;
        }
    }
}
