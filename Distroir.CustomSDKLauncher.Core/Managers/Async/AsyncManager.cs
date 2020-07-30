using System;
using System.Threading.Tasks;
using Distroir.CustomSDKLauncher.Core.Managers.Async.AsyncContentSerializers;
using Distroir.CustomSDKLauncher.Core.Utilities;

namespace Distroir.CustomSDKLauncher.Core.Managers.Async
{
    public class AsyncManager<T>
    {
        private readonly IAsyncContentSerializer<T> _serializer;
        private readonly AsyncLock _IOlock;

        public AsyncManager(IAsyncContentSerializer<T> serializer)
        {
            _serializer = serializer;
            _IOlock = new AsyncLock();
        }

        /// <summary>
        /// Starts loading data
        /// </summary>
        public void Load()
        {
            _serializer.Load();
        }

        /// <summary>
        /// Gets cached data or waits
        /// for data to be loaded and
        /// then returns the data
        /// </summary>
        public async Task<T> GetData()
        {
            await _IOlock.Lock();
            var data = await _serializer.GetData();
            _IOlock.Unlock();
            
            return data;
        }

        /// <summary>
        /// Saves the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task Save(T data)
        {
            await _IOlock.Lock();
            
            if (_serializer.CanSave)
                await _serializer.Save(data);
            else
                throw new NotSupportedException("This serializer does not support saving");
            
            _IOlock.Unlock();
        }
    }
}