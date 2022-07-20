using System.Runtime.Serialization;

namespace ExamenModuloC.Exceptions
{
    [Serializable]
    internal class InvalidPantalonSubTypeException : Exception
    {
        public InvalidPantalonSubTypeException(string? message) : base(message) { }
        public InvalidPantalonSubTypeException(Model.Enums.PrendaSubType invalidSubType) : base("Un pantalon no puede ser del subtipo: " + invalidSubType) { }
    }
}