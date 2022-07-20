using System.Runtime.Serialization;

namespace ExamenModuloC.Exceptions
{
    [Serializable]
    internal class InvalidStockException : Exception
    {
        public InvalidStockException()
        {
        }

        public InvalidStockException(string? message) : base(message)
        {
        }

        public InvalidStockException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}