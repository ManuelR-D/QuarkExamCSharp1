using ExamenModuloC.Model;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Presenter
{
    internal class InitializerPresenter
    {
        public InitializerPresenter(IViewCotizador view)
        {
            view.setIdTienda(1);
            view.setIdVendedor(1);
            IVendedorDTO v = (new VendedorDaoMySQL(Program.CONNECTION_STRING)).get(1);
            view.setLabelSellerAndId(v.Name + " " + v.LastName + " | " + v.Id);
            ITiendaDTO t = (new TiendaDaoMySQL(Program.CONNECTION_STRING).get(1));
            view.setLabelStoreName(t.Name);
            view.setLabelAddress(t.Address);
        }
    }
}
