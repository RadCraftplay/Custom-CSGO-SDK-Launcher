using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Migrators
{
    public interface IMigrator
    {
        bool RequiresMigration();
        void Migrate();
    }
}
