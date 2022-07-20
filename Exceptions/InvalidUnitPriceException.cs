using System.Runtime.Serialization;

namespace ExamenModuloC.Exceptions
{
    [Serializable]
    internal class InvalidUnitPriceException : Exception
    {
        public InvalidUnitPriceException()
        {
        }

        public InvalidUnitPriceException(string? message) : base(message)
        {
        }
    }
}