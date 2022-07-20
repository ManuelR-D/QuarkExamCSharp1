using ExamenModuloC.Model.Enums;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Prendas
{
    abstract internal class Prenda : IPrenda
    {
        protected int id;
        protected PrendaQuality quality;
        protected double unitPrice;
        protected int stock;
        protected IPrendaType type;
        public PrendaQuality Quality { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public IPrendaType Type { get; set; }
        public int Id { get { return this.id; } }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            IPrenda? prenda = obj as IPrenda;
            if (prenda == null)
                return false;
            if (prenda.Id == this.Id)
                return true;
            //If the two prendas don't have the same Id, we will check by prenda type
            if (!(prenda.Type.TypeOfPrenda == this.Type.TypeOfPrenda 
                && prenda.Type.PrendaSubTypes.Count == this.Type.PrendaSubTypes.Count 
                && prenda.Quality == this.Quality))
            {
                return false;
            }
            //If they are the same type and have the same amount of subtypes, we will check if those subtypes are exactly the same
            foreach (Model.Enums.PrendaSubType subtype in prenda.Type.PrendaSubTypes)
            {
                if (!this.Type.PrendaSubTypes.Contains(subtype))
                    return false;
            }
            //If all the previous conditions were met, they are equals
            return true;
        }
        public override string ToString()
        {
            return $"{this.Type}de calidad {this.Quality}";
        }
    }
}
