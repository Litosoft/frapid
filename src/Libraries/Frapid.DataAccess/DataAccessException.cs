using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Frapid.DataAccess
{
    [Serializable]
    public class DataAccessException : Exception
    {
        public DataAccessException()
        {
        }

        public DataAccessException([Localizable(true)] string message) : base(message)
        {
        }

        public DataAccessException([Localizable(true)] string message, Exception exception) : base(message, exception)
        {
        }

        protected DataAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}