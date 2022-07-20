using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model
{
    internal class CotizadorCamisa : Interface.ICotizador
    {
        public double cotizar(IPrenda prenda, int amount)
        {
            double finalUnitPrice = prenda.UnitPrice;
            if (prenda.Type.PrendaSubTypes.Contains(Enums.PrendaSubType.MangaCorta))
                finalUnitPrice *= 0.9;
            if (prenda.Type.PrendaSubTypes.Contains(Enums.PrendaSubType.CuelloMao))
                finalUnitPrice *= 1.03;
            if (prenda.Quality == Enums.PrendaQuality.Premium)
                finalUnitPrice *= 1.3;
            return finalUnitPrice * amount;
        }
    }
}
