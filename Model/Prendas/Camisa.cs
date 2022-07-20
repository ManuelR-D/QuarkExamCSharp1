using ExamenModuloC.Model.Enums;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Prendas
{
    [Serializable]
    internal class Camisa : Prenda
    {
        private const Enums.PrendaType CamisaType = Enums.PrendaType.Camisa;
        //No one, with the exception of DAOs and Builders should have an instance of this concrete class. Therefore, the Id property will only be
        //modifiable by those classes.
        public new int Id { get => this.id; set => this.id = value; }
        public void addSubType(Enums.PrendaSubType subType)
        {
            this.Type.PrendaSubTypes.Add(subType);
        }

        public Camisa()
        {
            this.Id = -1;
            this.Type = new PrendaType(CamisaType);
        }
        public Camisa(int id, Interface.IPrenda fromClone)
        {
            Id = id;
            this.Quality = fromClone.Quality;
            this.UnitPrice = fromClone.UnitPrice;
            this.Stock = fromClone.Stock;
            this.Type = new PrendaType(CamisaType);
            this.Type.TypeOfPrenda = fromClone.Type.TypeOfPrenda;
            //We shouldn't copy the references, but the values from the clone.
            fromClone.Type.PrendaSubTypes.ForEach(Type => this.Type.PrendaSubTypes.Add(Type));
        }
    }
}
