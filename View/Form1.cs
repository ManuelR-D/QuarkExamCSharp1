using ExamenModuloC.Model.Interface;

namespace ExamenModuloC.View
{
    public partial class Form1 : Form, Presenter.IViewCotizador
    {
        private int sellerId;
        private int storeId;

        public Form1()
        {
            InitializeComponent();
            new Presenter.InitializerPresenter(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.rbStandard.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Presenter.CotizadorPresenter(this);
        }

        public bool isCamisaChecked()
        {
            return this.rbCamisa.Checked;
        }

        public bool isPantalonChecked()
        {
            return this.rbPantalon.Checked;
        }

        public bool isCuelloMaoChecked()
        {
            return this.checkboxIsCuelloMao.Checked;
        }
        public bool isMangaCortaChecked()
        {
            return this.checkboxIsMangaCorta.Checked;
        }

        public bool isChupinChecked()
        {
            return this.checkboxIsChupin.Checked;
        }

        public bool isStandardChecked()
        {
            return this.rbStandard.Checked;
        }

        public bool isPremiumChecked()
        {
            return this.rbPremium.Checked;
        }

        public double getUnitPrice()
        {
            double ret;
            if(!Double.TryParse(this.textBoxPrecioUnitario.Text, out ret) || ret < 0)
            {
                MessageBox.Show("Por favor, introduzca un numero valido para precio unitario", "Precio unitario incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exceptions.InvalidUnitPriceException();
            }
            return ret;

        }

        public int getCantidad()
        {
            int ret;
            if (!Int32.TryParse(this.textBoxCantidad.Text, out ret) || ret < 0)
            {
                MessageBox.Show("Por favor, introduzca un numero de cantidad valido", "Cantidad incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exceptions.InvalidQuantityException();
            }
            return ret;
        }

        public void setCotizacion(double cotizacion)
        {
            this.labelCotizacion.Text = Convert.ToString(cotizacion);
        }
        public int getIdVendedor()
        {
            return this.sellerId;
        }

        public int getIdTienda()
        {
            return this.storeId;
        }

        public void setIdVendedor(int v)
        {
            this.sellerId = v;
        }

        public void setIdTienda(int t)
        {
            this.storeId = t;
        }

        public void setLabelStoreName(string name)
        {
            this.labelStoreName.Text = name;
        }

        public void setLabelAddress(string address)
        {
            this.labelStoreAddress.Text = address;
        }

        public void setLabelSellerAndId(string sellerNameAndId)
        {
            this.labelSellerAndId.Text = sellerNameAndId;
        }

        public void setLabelStock(int stockQuantity)
        {
            this.labelStock.Text = Convert.ToString(stockQuantity);
        }

        private void rbCamisa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCamisa.Checked)
            { 
                checkboxIsChupin.Checked = false;
            }
            new Presenter.StockPresenter(this);
        }

        private void rbPantalon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPantalon.Checked)
            {
                checkboxIsCuelloMao.Checked = false;
                checkboxIsMangaCorta.Checked = false;
            }
            new Presenter.StockPresenter(this);
        }

        private void checkboxIsMangaCorta_CheckedChanged(object sender, EventArgs e)
        {
            new Presenter.StockPresenter(this);
        }

        private void checkboxIsCuelloMao_CheckedChanged(object sender, EventArgs e)
        {
            new Presenter.StockPresenter(this);
        }

        private void checkboxIsChupin_CheckedChanged(object sender, EventArgs e)
        {
            new Presenter.StockPresenter(this);
        }

        private void rbPremium_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCamisa.Checked || rbPantalon.Checked)
                new Presenter.StockPresenter(this);
        }

        private void rbStandard_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCamisa.Checked || rbPantalon.Checked)
                new Presenter.StockPresenter(this);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Presenter.HistorialPresenter(this);
        }

        public int getStock()
        {
            return Int32.Parse(this.labelStock.Text);
        }
    }
}