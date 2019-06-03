﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Migrators
{
    public enum MigrationConflictSolution
    {
        NoConflict = 0,
        KeepProfilesXml = 1,
        KeepGamesXml = 2,
        KeepBoth = 4,
        NoDecission = 8
    }
}
