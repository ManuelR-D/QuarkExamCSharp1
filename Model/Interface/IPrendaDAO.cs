using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface IPrendaDAO
    {
        /**
         * Get the Prenda with the "id" from the db and returns the corresponding DTO as IPrenda
        */
        public IPrenda get(int id);

        /**
         * Saves the Prenda as json from the DTO to the db. Returns a NEW instance of Prenda with the new Id that the db has set.
         */
        public IPrenda save(IPrenda prenda);

        /**
         * Deletes a Prenda with the "id" in the db. Returns true if at least one row was affected
         */
        public bool delete(int id);
        /**
         * Updates the Prenda with the id prenda.Id in the db. Returns true if at least one row was affected
         */
        public bool update(IPrenda prenda);
    }
}
