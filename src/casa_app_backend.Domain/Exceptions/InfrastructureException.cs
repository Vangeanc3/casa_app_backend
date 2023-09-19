using System.Runtime.Serialization;
    
namespace casa_app_backend.Domain.Exceptions
{
    [Serializable]
    public class InfrastructureException : BaseException
    {
         public InfrastructureException(string? message)
            : base(500, message)
        {
        }

        public InfrastructureException(string? message, Exception? innerException)
            : base(500, message, innerException)
        {
        }

        public InfrastructureException(int code, string? message)
            : base(code, message)
        {
        }

        public InfrastructureException(int code, string? message, Exception? innerException)
            : base(code, message, innerException)
        {
        }

        protected InfrastructureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Code = 500;
        }
    }
}