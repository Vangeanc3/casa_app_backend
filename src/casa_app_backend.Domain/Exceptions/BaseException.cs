using System.Runtime.Serialization;

namespace casa_app_backend.Domain.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        public int Code { get; set; }

         protected BaseException(int code, string? message)
            : base(message)
        {
            Code = code;
        }

        protected BaseException(int code, string? message, Exception? innerException)
            : base(message, innerException)
        {
            Code = code;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}