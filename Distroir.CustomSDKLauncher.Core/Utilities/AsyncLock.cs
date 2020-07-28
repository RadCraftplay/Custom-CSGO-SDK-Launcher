using System.Threading;
using System.Threading.Tasks;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class AsyncLock
    {
        private readonly SemaphoreSlim _semaphore;
        
        public AsyncLock()
        {
            _semaphore = new SemaphoreSlim(1, 1);
        }

        public async Task Lock()
        {
            await _semaphore.WaitAsync();
        }

        public void Unlock()
        {
            _semaphore.Release();
        }
    }
}