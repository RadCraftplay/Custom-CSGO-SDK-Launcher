using System.Threading.Tasks;
using Distroir.CustomSDKLauncher.Core.Managers.Serializers;
using Distroir.CustomSDKLauncher.Core.Utilities;

namespace Distroir.CustomSDKLauncher.Core.Managers.Async
{
    public class AsyncManager<T>
    {
        private readonly ISerializer<T> _serializer;
        private readonly AsyncLock _IOlock;
        private Task<T> _loadingTask;
        private T _storedValue;

        public AsyncManager(ISerializer<T> serializer)
        {
            _IOlock = new AsyncLock();
            _serializer = serializer;
            _loadingTask = LoaderWrapper();
        }
        
        private async Task<T> LoaderWrapper()
        {
            await _IOlock.Lock();
            var retVal = await Task.Factory.StartNew(() => _serializer.Deserialize());
            _storedValue = retVal;
            _IOlock.Unlock();

            return retVal;
        }

        public void Load()
        {
            _loadingTask.ConfigureAwait(false);
        }

        public async Task Reload()
        {
            await _IOlock.Lock();

            _loadingTask = LoaderWrapper();
            _storedValue = default(T);
            await _loadingTask;

            _IOlock.Unlock();
        }

        public async Task<T> GetAsync()
        {
            await _IOlock.Lock();
            if (_storedValue != null)
                return _storedValue;
            _IOlock.Unlock();

            return await _loadingTask;
        }

        public async Task Save(T toSave)
        {
            await _IOlock.Lock();
            _storedValue = toSave;
            await Task.Factory.StartNew(() => _serializer.Serialize(toSave));
            _IOlock.Unlock();
        }
    }
}