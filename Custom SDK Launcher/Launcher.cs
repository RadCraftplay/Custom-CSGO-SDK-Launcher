using System.Diagnostics;
using System.IO;

namespace Custom_SDK_Launcher
{
    public class Launcher
    {
        public static void Launch(Profile p, SDKApplication app)
        {
            //Create strings
            string filename = string.Empty;
            string arguments = string.Empty;

            //Select configuration
            switch (app)
            {
                case SDKApplication.Hammer:
                    filename = GetToolPath(p, app);
                    arguments = "-nop4 ";
                    break;
                case SDKApplication.HLMV:
                    filename = GetToolPath(p, app);
                    break;
                case SDKApplication.FacePoser:
                    filename = GetToolPath(p, app);
                    arguments = "-nop4 ";
                    break;
            }

            //Add gamedir to arguments
            arguments += string.Format("-game {0}{1}{0}", '"', p.GetGameinfoDirectory());

            //Create process
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = p.GetBinDirectory();
            proc.StartInfo.FileName = filename;
            proc.StartInfo.Arguments = arguments;
            //Start process
            proc.Start();
        }

        /// <summary>
        /// Gets path to executable file of specified tool
        /// </summary>
        /// <param name="p">Selected profile</param>
        /// <param name="app">App to launch</param>
        /// <returns>Path to executable of specified tool</returns>
        static string GetToolPath(Profile p, SDKApplication app)
        {
            switch (app)
            {
                case SDKApplication.Hammer:
                    return Path.Combine(p.GetBinDirectory(), "hammer.exe");
                case SDKApplication.HLMV:
                    return Path.Combine(p.GetBinDirectory(), "hlmv.exe");
                case SDKApplication.FacePoser:
                    return Path.Combine(p.GetBinDirectory(), "hlfaceposer.exe");
            }

            return string.Empty;
        }
    }

    /// <summary>
    /// As the name suggests
    /// </summary>
    public enum SDKApplication
    {
        /// <summary>
        /// Hammer world editor
        /// </summary>
        Hammer,
        /// <summary>
        /// Model viewer
        /// </summary>
        HLMV,
        /// <summary>
        /// Face poser
        /// </summary>
        FacePoser
    }
}
