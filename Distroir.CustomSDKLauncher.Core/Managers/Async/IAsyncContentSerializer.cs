using System.Threading.Tasks;

namespace Distroir.CustomSDKLauncher.Core.Managers.Async
{
    public interface IAsyncContentSerializer<T>
    {
        bool CanSave { get; }
        void Load();
        Task<T> GetData();
        Task Save(T data);
    }
}