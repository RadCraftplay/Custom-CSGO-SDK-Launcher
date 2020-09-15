using System.Collections.Generic;

namespace Distroir.CustomSDKLauncher.Core.Managers
{
    public interface IManager<T>
    {
        /// <summary>
        /// List of serializable objects
        /// </summary>
        List<T> Objects { get; set; }
        
        /// <summary>
        /// Loads objects from file
        /// </summary>
        void Load();

        /// <summary>
        /// Tries to load objects from file
        /// </summary>
        bool TryLoad();

        /// <summary>
        /// Saves objects to file
        /// </summary>
        void Save();
    }
}