using ExamenModuloC.Model.Enums;
using System.Runtime.Serialization;

namespace ExamenModuloC.Exceptions
{
    [Serializable]
    internal class InvalidPrendaTypeException : Exception
    {
        public InvalidPrendaTypeException(PrendaType prendaType) : base("La prenda: " + prendaType + " no existe") { }
        public InvalidPrendaTypeException(string message) : base(message) { }
    }
}