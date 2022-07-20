using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface ITiendaDAO
    {

        /**
         * Get the Tienda with the "id" from the db and returns the corresponding DTO
         */
        public ITiendaDTO get(int id);

        /**
         * Saves the Tienda with the name and lastName from the DTO to the db. Sets the created Id to the DTO
         * Note that ITiendaDTO id is mutable.
         */
        public ITiendaDTO save(ITiendaDTO vendedorDTO);

        /**
         * Deletes a Tienda with the "id" in the db. Returns true if at least one row was affected
         */
        public bool delete(int id);
        /**
         * Updates the Tienda with the id updatedVendedor.Id in the db. Returns true if at least one row was affected
         */
        public bool update(ITiendaDTO updatedVendedor);
    }
}
