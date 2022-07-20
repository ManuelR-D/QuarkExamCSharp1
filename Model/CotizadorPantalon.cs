using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model
{
    internal class CotizadorPantalon : Interface.ICotizador
    {
        public double cotizar(IPrenda prenda, int amount)
        {
            double finalUnitPrice = prenda.UnitPrice;
            if (prenda.Type.PrendaSubTypes.Contains(Enums.PrendaSubType.Chupin))
                finalUnitPrice *= 1.12;
            if (prenda.Quality == Enums.PrendaQuality.Premium)
                finalUnitPrice *= 1.3;
            return finalUnitPrice * amount;
        }
    }
}
