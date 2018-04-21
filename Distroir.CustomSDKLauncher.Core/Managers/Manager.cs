/*
Custom SDK Launcher
Copyright (C) 2017-2018 Distroir

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Managers
{
    public class Manager<T>
    {
        /// <summary>
        /// List of serializable objects
        /// </summary>
        public List<T> Objects;
        /// <summary>
        /// Serializer used to serialize objects
        /// </summary>
        ContentSerializer<T> Serializer;

        public Manager(ContentSerializer<T> serializer)
        {
            Serializer = serializer;
        }

        /// <summary>
        /// Loads objects from file
        /// </summary>
        public void Load()
        {
            Objects = Serializer.Load().ToList();
        }

        /// <summary>
        /// Tries to load objects from file
        /// </summary>
        public bool TryLoad()
        {
            try
            {
                Load();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Saves objects to file
        /// </summary>
        public void Save()
        {
            if (Serializer.CanSave)
                Serializer.Save(Objects.ToArray());
            else
                throw new NotSupportedException("This serializer does not support saving");
        }
    }
}
