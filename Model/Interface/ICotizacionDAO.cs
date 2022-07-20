using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface ICotizacionDAO
    {
        /**
        * Get the Cotizacion with the "id" from the db and returns the corresponding DTO as ICotizacion
        */
        public ICotizacionDTO get(int id);

        /**
         * Saves the Cotizacion as json from the DTO to the db. Returns a NEW instance of Cotizacion with the new Id that the db has set.
         */
        public ICotizacionDTO save(ICotizacionDTO Cotizacion);

        /**
         * Deletes a Cotizacion with the "id" in the db. Returns true if at least one row was affected
         */
        public bool delete(int id);
        /**
         * Updates the Cotizacion with the id Cotizacion.Id in the db. Returns true if at least one row was affected
         */
        public bool update(ICotizacionDTO Cotizacion);
    }
}
