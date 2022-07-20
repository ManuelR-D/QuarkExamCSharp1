using ExamenModuloC.Model.Enums;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Prendas
{
    internal class Pantalon : Prenda
    {
        private const Enums.PrendaType PantalonType = Enums.PrendaType.Pantalon;
        //No one, with the exception of instatiators (DAOs and Builders) should have an instance of this concrete class.
        //Therefore, the Id property will only be modifiable by those classes. For the exterior this will be immutable (see IPrenda)
        public new int Id { get => this.id; set => this.id = value; }      
        public void setSubType(Enums.PrendaSubType subType)
        {
            this.Type.PrendaSubTypes.Add(subType);
        }

        public Enums.PrendaSubType getPrendaSubType()
        {
            return this.Type.PrendaSubTypes.FirstOrDefault();
        }

        public Pantalon()
        {
            this.Id = -1;
            this.Type = new PrendaType(PantalonType);
        }
        public Pantalon(int id, Interface.IPrenda fromClone)
        {
            Id = id;
            this.Quality = fromClone.Quality;
            this.UnitPrice = fromClone.UnitPrice;
            this.Stock = fromClone.Stock;
            this.Type = new PrendaType(PantalonType);
            this.Type.TypeOfPrenda = fromClone.Type.TypeOfPrenda;
            //We shouldn't copy the references, but the values from the clone.
            fromClone.Type.PrendaSubTypes.ForEach(Type => this.Type.PrendaSubTypes.Add(Type));
        }
    }
}
