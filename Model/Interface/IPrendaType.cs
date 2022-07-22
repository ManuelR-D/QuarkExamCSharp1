using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface IPrendaType
    {
        Enums.PrendaType TypeOfPrenda { get; }
        public List<Enums.PrendaSubType> PrendaSubTypes { get; }
    }
}
