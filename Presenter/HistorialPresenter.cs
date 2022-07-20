using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenModuloC.Model.Interface;
using ExamenModuloC.Model;
namespace ExamenModuloC.Presenter
{
    internal class HistorialPresenter
    {
        public HistorialPresenter(IViewCotizador view)
        {
            int sellerId = view.getIdVendedor();
            IVendedorDTO v = (new VendedorDaoMySQL(Program.CONNECTION_STRING)).get(sellerId);
            List<ICotizacionDTO> list = (new CotizacionDaoMySQL(Program.CONNECTION_STRING)).getCotizacionesFromVendedor(v);
            StringBuilder sb = new StringBuilder();
            foreach(ICotizacionDTO c in list)
            {
                sb.Append(c.ToString() + Environment.NewLine);
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
