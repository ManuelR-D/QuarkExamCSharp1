using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenModuloC.Model;
using ExamenModuloC.Exceptions;
using ExamenModuloC.Model.Interface;

namespace ExamenModuloC.Presenter
{
    internal class CotizadorPresenter
    {
        public CotizadorPresenter(IViewCotizador view)
        {
            try
            {
                if (view.getCantidad() > view.getStock())
                {
                    MessageBox.Show("La cantidad a cotizar es mayor que el stock disponible del producto", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } catch (Exception e)
            {
                return;
            }
            
            int id = view.getIdVendedor();
            IVendedorDTO vendedorDTO = new VendedorDaoMySQL(Program.CONNECTION_STRING).get(id);
            IPrenda prenda = Utils.PrendaFactory.getPrendaFromView(view);
            try
            {
                prenda.UnitPrice = view.getUnitPrice();
            } catch (Exceptions.InvalidUnitPriceException e)
            {
                return;
            }
            Vendedor vendedor = new Vendedor(vendedorDTO.Id, vendedorDTO.Name, vendedorDTO.LastName, vendedorDTO.WorkplaceId);
            Cotizacion cotizacion = vendedor.cotizar(prenda, view.getCantidad());
            (new CotizacionDaoMySQL(Program.CONNECTION_STRING)).save(cotizacion);
            view.setCotizacion(cotizacion.Total);
        }
    }
}
