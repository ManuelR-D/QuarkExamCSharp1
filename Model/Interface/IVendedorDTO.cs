using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface IVendedorDTO
    {
        public int Id { get; }
        public string Name { get; }
        public string LastName { get; }
        public int WorkplaceId { get; }
    }
}
