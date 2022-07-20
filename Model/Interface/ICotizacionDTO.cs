using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface ICotizacionDTO
    {
        public int Id { get; }
        public DateTime DateTime { get; }
        public int IdVendedor { get; }
        public IPrenda Item { get; } 
        public int ItemAmount { get; }
        public double Total { get; }

    }
}
