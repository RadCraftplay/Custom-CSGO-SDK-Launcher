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

namespace Distroir.CustomSDKLauncher.Core.Utilities.Checker
{
    internal class EmptyValueValidator : IValidator
    {
        public string LastErrorMessage { get; private set; }
        private Game _gameToValidate;

        public EmptyValueValidator(Game toValidate)
        {
            _gameToValidate = toValidate;
        }

        public bool Validate()
        {
            bool invalid = string.IsNullOrWhiteSpace(_gameToValidate.GameDir)
                        || string.IsNullOrWhiteSpace(_gameToValidate.GameinfoDirName)
                        || string.IsNullOrWhiteSpace(_gameToValidate.Name);

            if (invalid)
                LastErrorMessage = "One or more fields are empty";

            return !invalid;
        }
    }
}