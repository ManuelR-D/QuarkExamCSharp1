using System.Runtime.Serialization;

namespace ExamenModuloC.Exceptions
{
    [Serializable]
    internal class NoSuchPrendaException : Exception
    {
        public NoSuchPrendaException()
        {
        }

        public NoSuchPrendaException(string? message) : base(message)
        {
        }

        public NoSuchPrendaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoSuchPrendaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}