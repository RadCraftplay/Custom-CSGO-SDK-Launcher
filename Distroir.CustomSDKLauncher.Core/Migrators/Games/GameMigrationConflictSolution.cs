using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Migrators.Games
{
    public enum GameMigrationConflictSolution
    {
        NoConflict = 0,
        KeepProfilesXml = 1,
        KeepGamesXml = 2,
        KeepBoth = 4,
        NoDecision = 8,
        NoDecisionThisTime = 16
    }
}
