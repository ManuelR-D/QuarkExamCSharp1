using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface ICotizador
    {
        public double cotizar(IPrenda prenda, int amount);
    }
}
