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
using System.Collections.Generic;

namespace Distroir.CustomSDKLauncher.Core.Utilities.Checker
{
    public class GameChecker
    {
        private readonly List<IValidator> _validators = new List<IValidator>();

        public string LastErrorMessage { get; private set; }

        public GameChecker(Game gameToCheck)
        {
            _validators.Add(new EmptyValueValidator(gameToCheck));
            _validators.Add(new DirectoryValidator(gameToCheck));
            _validators.Add(new ToolValidator(gameToCheck.GameDir));
        }

        public bool IsValid()
        {
            foreach (IValidator validator in _validators)
            {
                if (!validator.Validate())
                {
                    LastErrorMessage = validator.LastErrorMessage;
                    return false;
                }
            }

            return true;
        }
    }
}
