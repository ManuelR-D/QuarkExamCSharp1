using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface ITiendaDTO
    {
        public int Id { get; }
        public string Name { get; }
        public string Address { get; }
        public List<IPrenda> Items { get; }
    }
}
