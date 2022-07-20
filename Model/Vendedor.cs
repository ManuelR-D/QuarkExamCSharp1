using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model
{
    internal class Vendedor : Interface.IVendedorDTO
    {
        private int id;
        private string name;
        private string lastName;
        private static IDictionary<Enums.PrendaType,Interface.ICotizador> cotizadores = new Dictionary<Enums.PrendaType,Interface.ICotizador>()
        { 
            [Enums.PrendaType.Camisa] = new CotizadorCamisa(),
            [Enums.PrendaType.Pantalon] = new CotizadorPantalon()
        };
        private int workplaceId;
        public int Id { get { return this.id; } set => this.id = value; }

        public string Name { get { return this.name; } }

        public string LastName { get { return this.lastName; } }

        public int WorkplaceId { get { return this.workplaceId; } }

        public Vendedor(int id, string? name, string? lastName, int workplaceId)
        {
            this.id = id;
            this.name = name != null ? name : "";
            this.lastName = lastName != null ? lastName : "";
            this.workplaceId = workplaceId;
        }
        public Vendedor(string? name, string? lastName, int workplaceId)
        {
            this.id = -1;
            this.name = name != null ? name : "";
            this.lastName = lastName != null ? lastName : "";
            this.workplaceId = workplaceId;
        }

        public Cotizacion cotizar(Interface.IPrenda prenda, int amount)
        {
            Interface.ICotizador? cotizador = null;
            if(!cotizadores.TryGetValue(prenda.Type.TypeOfPrenda,out cotizador))
            {
                throw new Exceptions.InvalidPrendaTypeException(prenda.Type.TypeOfPrenda);
            }
            double finalPrice = cotizador.cotizar(prenda, amount);
            DateTime dateTime = DateTime.Now;
            Cotizacion cotizacion = new Cotizacion(dateTime, this.id, prenda, amount, finalPrice);
            return cotizacion;
        }
    }
}
