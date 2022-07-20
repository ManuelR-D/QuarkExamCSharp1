using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model
{
    internal class Tienda : Interface.ITiendaDTO
    {
        private int id;
        private string name;
        private string address;
        private List<IPrenda> items;
        public string Name { get { return this.name; } }

        public string Address { get { return this.address; } }

        public int Id { get { return this.id; } set => this.id = value; }
        public List<IPrenda> Items { get { return this.items; } }

        public Tienda(int id, string name, string address, List<IPrenda>? items)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.items = items == null ? new List<IPrenda>() : items;
        }
        public Tienda(string name, string address, List<IPrenda>? items)
        {
            this.name = name;
            this.address = address;
            this.items = items == null ? new List<IPrenda>() : items;
        }
    }
}
