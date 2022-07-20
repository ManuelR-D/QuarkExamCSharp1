using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Exceptions
{
    internal class InvalidCamisaSubTypeException : Exception
    {
        public InvalidCamisaSubTypeException(Model.Enums.PrendaSubType invalidSubType) : base("Una camisa no puede ser del subtipo: " + invalidSubType) { }
    }
}
