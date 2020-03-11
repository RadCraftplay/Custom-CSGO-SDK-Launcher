namespace Distroir.CustomSDKLauncher.Core.Launchers
{
    public interface IConfigurableApp : IApp
    {
        bool Configure();
    }
}