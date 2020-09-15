using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders
{
    public class CustomJavaPathFinder : IJavaPathFinder
    {
        private readonly TextBox _pathTextBox;
        public string Path => _pathTextBox.Text;


        public CustomJavaPathFinder(ref TextBox pathTextBox)
        {
            _pathTextBox = pathTextBox;
        }
        
        public bool CanGetPath()
        {
            return Utils.TryLaunch(_pathTextBox.Text);
        }
    }
}