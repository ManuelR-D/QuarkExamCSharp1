using ExamenModuloC.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Builders
{
    internal class CamisaBuilder : Interface.IPrendaBuilder
    {
        private Prendas.Camisa result;
        private LinkedList<Enums.PrendaSubType> subtypes;
        private static readonly HashSet<Enums.PrendaSubType> validSubTypes = new HashSet<Enums.PrendaSubType>() 
        { 
            Enums.PrendaSubType.MangaLarga,
            Enums.PrendaSubType.MangaCorta,
            Enums.PrendaSubType.CuelloComun,
            Enums.PrendaSubType.CuelloMao
        };

        public CamisaBuilder()
        {
            this.result = new Prendas.Camisa();
            this.subtypes = new LinkedList<Enums.PrendaSubType>();
        }
        public void buildPrenda()
        {
            this.result = new Prendas.Camisa();
        }

        public void buildType()
        {
            this.result.Type.TypeOfPrenda = Enums.PrendaType.Camisa;
        }
        
        public void buildSubTypes()
        {
            foreach(Enums.PrendaSubType subtype in subtypes)
            {
                if(!validSubTypes.Contains(subtype)) {
                    throw new Exceptions.InvalidCamisaSubTypeException(subtype);
                }
                this.result.Type.PrendaSubTypes.Add(subtype);
            }
        }

        public void reset()
        {
            this.result = new Prendas.Camisa();
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
