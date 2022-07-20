using ExamenModuloC.Model.Enums;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Prendas
{
    internal class PrendaType : IPrendaType
    {
        private Enums.PrendaType type;
        private List<Enums.PrendaSubType> subTypes;

        
        public List<Enums.PrendaSubType> PrendaSubTypes { get { return this.subTypes; } }

        Enums.PrendaType IPrendaType.TypeOfPrenda { get => this.type; set { _ = this.type; } }

        public PrendaType(Enums.PrendaType type)
        {
            this.type = type;
            this.subTypes = new List<Enums.PrendaSubType>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Enums.PrendaSubType subtype in this.subTypes)
            {
                sb.Append(Enums.PrendaSubTypeFriendlyString.toFriendlyString(subtype) + ", ");
            }
            return $"{this.type}, {sb.ToString()}";
        }
    }
}
