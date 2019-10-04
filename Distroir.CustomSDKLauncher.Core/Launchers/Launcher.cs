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
            if (!Enumerable.Range(0, 2).Contains(applicationId))
                throw new ArgumentOutOfRangeException("Application id has to be a number between 0 and two");

            if (Apps.Count != 3)
                throw new IndexOutOfRangeException("Launcher has to have exactly three applications");

            IApp selectedApp = Apps[applicationId];
            selectedApp.Launch(activeGame);
        }
    }
}
