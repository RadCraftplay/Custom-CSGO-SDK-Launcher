using System;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;

namespace Distroir.CustomSDKLauncher.Core.Launchers
{
    public class AppConfigurator
    {
        public string DisplayText { get; }
        public Func<IApp, IApp> Action;
        
        public AppConfigurator(string displayText, Func<IApp, IApp> action)
        {
            Action = action;
            DisplayText = displayText;
        }
    }
}