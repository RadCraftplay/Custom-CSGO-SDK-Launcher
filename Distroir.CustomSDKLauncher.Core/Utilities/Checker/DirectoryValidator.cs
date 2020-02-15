/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

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
using System.IO;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities.Checker
{
    internal class DirectoryValidator : IValidator
    {
        public string LastErrorMessage { get; private set; }
        private readonly Game _gameToValidate;

        public DirectoryValidator(Game toValidate)
        {
            _gameToValidate = toValidate;
        }

        public bool Validate()
        {
            bool valid = true;
            StringBuilder errorMessageBuilder = new StringBuilder();

            string gameInfoDirPath = Path.Combine(_gameToValidate.GameDir, _gameToValidate.GameinfoDirName);

            if (!Directory.Exists(_gameToValidate.GameDir))
            {
                LogMissingDirectory(errorMessageBuilder, _gameToValidate.GameDir);
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