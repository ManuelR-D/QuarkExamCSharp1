using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface IPrendaBuilder
    {
        public void reset();
        public void buildPrenda();
        public void buildType();
        public void buildSubTypes();
        public void addSubtype(Enums.PrendaSubType subtype);
        public void buildQuality(Enums.PrendaQuality quality);
        public IPrenda getResult();
    }
}
