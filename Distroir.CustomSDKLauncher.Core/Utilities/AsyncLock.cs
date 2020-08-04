/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
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