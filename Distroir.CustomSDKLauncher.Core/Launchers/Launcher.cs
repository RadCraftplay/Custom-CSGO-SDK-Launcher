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
using Distroir.CustomSDKLauncher.Core.Launchers.Apps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Distroir.CustomSDKLauncher.Core.Launchers
{
    public abstract class Launcher
    {
        public abstract List<IApp> Apps { get; }

        /// <summary>
        /// Launches application with selected id
        /// </summary>
        /// <param name="applicationId">Id of an application (between 0 and 2)</param>
        /// <param name="activeGame">Currently active game</param>
        public void Launch(int applicationId, Game activeGame)
        {
            if (!Enumerable.Range(0, 3).Contains(applicationId))
                throw new ArgumentOutOfRangeException("Application id has to be a number between 0 and two");

            if (Apps.Count != 3)
                throw new IndexOutOfRangeException("Launcher has to have exactly three applications");

            IApp selectedApp = Apps[applicationId];
            selectedApp.Launch(activeGame);
        }
    }
}
