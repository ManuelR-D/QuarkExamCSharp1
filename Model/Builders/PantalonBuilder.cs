using ExamenModuloC.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Builders
{
    internal class PantalonBuilder : Interface.IPrendaBuilder
    {
        private Prendas.Pantalon result;
        private LinkedList<Enums.PrendaSubType> subtypes;
        private static readonly HashSet<Enums.PrendaSubType> validSubTypes = new HashSet<Enums.PrendaSubType>() 
        { 
            Enums.PrendaSubType.Chupin,
            Enums.PrendaSubType.Comun
        };

        public PantalonBuilder()
        {
            this.result = new Prendas.Pantalon();
            this.subtypes = new LinkedList<Enums.PrendaSubType>();
        }
        public void buildPrenda()
        {
            this.result = new Prendas.Pantalon();
        }

        public void buildType()
        {
            this.result.Type.TypeOfPrenda = Enums.PrendaType.Camisa;
        }
        
        public void buildSubTypes()
        {
            if(this.subtypes.Count > 1)
            {
                throw new Exceptions.InvalidPantalonSubTypeException("Un pantalon solo puede tener 1 subtipo");
            }
            Enums.PrendaSubType subtype = this.subtypes.First();
            if(!validSubTypes.Contains(subtype))
            {
                throw new Exceptions.InvalidPantalonSubTypeException(subtype);
            }
            this.result.Type.PrendaSubTypes.Add(subtype);
        }

        public void reset()
        {
            this.result = new Prendas.Pantalon();
            this.subtypes.Clear();
        }

        public void addSubtype(Enums.PrendaSubType subtype)
        {
            this.subtypes.AddLast(subtype);
        }
        public void buildQuality(PrendaQuality quality)
        {
            this.result.Quality = quality;
        }

        public Interface.IPrenda getResult()
        {
            return this.result;
        }

        
    }
}
