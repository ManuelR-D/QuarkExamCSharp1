using ExamenModuloC.Model;
using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Presenter
{
    internal class StockPresenter
    {
        public StockPresenter(IViewCotizador view)
        {
            TiendaDaoMySQL dao = new TiendaDaoMySQL(Program.CONNECTION_STRING);
            ITiendaDTO t = dao.get(view.getIdTienda());
            dao.getItems(t);
            IPrenda prendaToSearch = Utils.PrendaFactory.getPrendaFromView(view);
            int stock = this.getStock(prendaToSearch, t);
            view.setLabelStock(stock);
        }

        private int getStock(IPrenda prendaToSearch, ITiendaDTO t)
        {
            foreach (IPrenda prenda in t.Items)
            {
                if(prendaToSearch.Equals(prenda))
                    return prenda.Stock;
            }
            return 0;
        }
    }
}
