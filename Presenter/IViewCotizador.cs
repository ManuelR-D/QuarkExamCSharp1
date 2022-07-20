using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Presenter
{
    internal interface IViewCotizador
    {
        public bool isCamisaChecked();
        public bool isPantalonChecked();
        public bool isCuelloMaoChecked();
        public bool isMangaCortaChecked();
        public bool isChupinChecked();
        public bool isStandardChecked();
        public bool isPremiumChecked();
        public double getUnitPrice();
        public int getCantidad();
        public void setCotizacion(double cotizacion);
        public int getIdVendedor();
        public int getIdTienda();
        public int getStock();
        public void setIdVendedor(int id);
        public void setIdTienda(int id);
        public void setLabelStoreName(string name);
        public void setLabelAddress(string address);
        public void setLabelSellerAndId(string sellerNameAndId);
        public void setLabelStock(int stockQuantity);

    }
}
