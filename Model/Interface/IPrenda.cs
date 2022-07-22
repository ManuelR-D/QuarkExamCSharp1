using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface IPrenda
    {
        int Id { get; }
        Enums.PrendaQuality Quality { get; }
        double UnitPrice { get; set; }
        int Stock { get; set; }
        IPrendaType Type { get; }
    }
}
