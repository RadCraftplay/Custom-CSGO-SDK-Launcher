using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana.Exceptions
{

    [Serializable]
    public class UnknownGameIdException : Exception
    {
        string GameId = null;

        public UnknownGameIdException() { }
        public UnknownGameIdException(string message) : base(message) { }
        public UnknownGameIdException(string message, Exception inner) : base(message, inner) { }
        protected UnknownGameIdException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string Message
        {
            get
            {
                return "Game id is not associated with any compatble game\nGame is probably not supported";
            }
        }
    }
}
