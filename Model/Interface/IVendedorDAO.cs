using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface IVendedorDAO
    {

        /**
         * Get the Vendedor with the "id" from the db and returns the corresponding DTO
         */
        public IVendedorDTO get(int id);

        /**
         * Saves the Vendedor with thename and lastName from the DTO to the db. Sets the id of the DTO to the generated id in the database.
         * Note that IVendedorDTO id is then mutable
         */
        public IVendedorDTO save(IVendedorDTO vendedorDTO);

        /**
         * Deletes a Vendedor with the "id" in the db. Returns true if at least one row was affected
         */
        public bool delete(int id);
        /**
         * Updates the Vendedor with the id updatedVendedor.Id in the db. Returns true if at least one row was affected
         */
        public bool update(IVendedorDTO updatedVendedor);
    }
}
