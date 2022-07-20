using ExamenModuloC.Model.Enums;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Director
{
    internal class PrendaDirector
    {
        private Interface.IPrendaBuilder builder;
        private List<Enums.PrendaSubType> subTypes;

        public PrendaDirector(IPrendaBuilder builder, List<PrendaSubType> subTypes)
        {
            this.builder = builder;
            this.subTypes = subTypes;
        }
        public PrendaDirector(IPrendaBuilder builder)
        {
            this.builder = builder;
            this.subTypes = new List<PrendaSubType>();
        }
        public void changeBuilder(IPrendaBuilder builder)
        {
            this.builder = builder;
        }

        public void addSubType(PrendaSubType subtype)
        {
            this.subTypes.Add(subtype);
        }
        public void removeSubType(PrendaSubType subType)
        {
            this.subTypes.Remove(subType);
        }

        public void makeStandard()
        {
            make();
            this.builder.buildQuality(Enums.PrendaQuality.Standard);
        }

        public void makePremium()
        {
            make();
            this.builder.buildQuality(Enums.PrendaQuality.Premium);
        }

        private void make()
        {
            this.builder.reset();
            this.builder.buildPrenda();
            this.builder.buildType();
            foreach (Enums.PrendaSubType subType in this.subTypes)
            {
                this.builder.addSubtype(subType);
            }
            this.builder.buildSubTypes();
        }
    }
}
