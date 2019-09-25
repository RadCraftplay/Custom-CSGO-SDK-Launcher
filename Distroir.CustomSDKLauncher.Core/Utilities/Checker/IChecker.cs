using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities.Checker
{
    interface IChecker
    {
        string LastErrorMessage { get; }
        bool Validate();
    }
}
