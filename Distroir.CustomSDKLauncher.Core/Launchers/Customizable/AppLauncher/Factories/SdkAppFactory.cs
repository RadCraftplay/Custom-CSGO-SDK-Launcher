using System.Drawing;
using System.IO;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public class SdkAppFactory : IAppInfoFactory
    {
        public SdkAppFactory(SdkApplication application)
        {
            Application = application;
        }

        public SdkApplication Application { get; }
        
        public AppInfo GetInfo()
        {
            var info = GetToolStartInfo(Application);
            info.DisplayText = GetDisplayText();
            info.Icon = GetIcon();

            return info;
        }
        
        private string GetDisplayText()
        {
            switch (Application)
            {
                case SdkApplication.Hammer:
                    return "Hammer World Editor";
                case SdkApplication.HLMV:
                    return "Model Viewer";
                case SdkApplication.FacePoser:
                    return "Face Poser";
                default:
                    return "Source SDK application";
            }
        }

        private Image GetIcon()
        {
            switch (Application)
            {
                case SdkApplication.HLMV:
                    return Data.ModelViewerIcon;
                case SdkApplication.FacePoser:
                    return Data.FacePoserIcon;
                default:
                    return Data.HammerIcon;
            }
        }

        private AppInfo GetToolStartInfo(SdkApplication app)
        {
            var info = new AppInfo();
            info.Path = GetToolPath(app);

            info.UseCustomWorkingDirectory = true;
            info.CustomWorkingDirectory = Path.Combine("{GameDir}", "{GameinfoDir}");

            info.UseCustomArguments = true;
            if (app != SdkApplication.HLMV)
            {
                info.Arguments = "-nop4 ";
            }
            info.Arguments += string.Format("-game {0}{1}{0}", '"', Path.Combine("{GameDir}", "{GameinfoDir}"));

            return info;
        }

        private string GetToolPath(SdkApplication app)
        {
            switch (app)
            {
                case SdkApplication.FacePoser:
                    return Path.Combine("{GameBinDir}", "hlfaceposer.exe");
                case SdkApplication.HLMV:
                    return Path.Combine("{GameBinDir}", "hlmv.exe");
                default:
                    return Path.Combine("{GameBinDir}", "hammer.exe");
            }
        }
    }
}