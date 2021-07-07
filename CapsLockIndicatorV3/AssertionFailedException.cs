using System;
using System.Runtime.Serialization;

namespace CapsLockIndicatorV3
{
    [Serializable]
    internal class AssertionFailedException : Exception
    {
        public AssertionFailedException()
        {
        }

        public AssertionFailedException(string message) : base(message)
        {
        }

        public AssertionFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AssertionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}