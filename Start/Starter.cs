using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenModuloC.Model;
using ExamenModuloC.Model.Builders;
using ExamenModuloC.Model.Director;
using ExamenModuloC.Model.Enums;
using ExamenModuloC.Model.Prendas;
using ExamenModuloC.Model.Interface;
using System.Data.SqlClient;

namespace ExamenModuloC.Start
{
    internal class Starter
    {
        private List<IPrenda> initialStock = new List<IPrenda>();
        private ITiendaDTO fakeStore;
        private IVendedorDTO saulGoodMan;
        public void start()
        {
            this.freshStart();
            fakeStore = this.createFakeStore();
            this.createInitialStock();
            saulGoodMan = this.createSaulGoodman();
        }

        private void freshStart()
        {
            using (SqlConnection connection = new SqlConnection(Program.CONNECTION_STRING))
            {
                connection.Open();
                String query = @"
                DELETE FROM dbo.cotizacion;                
                DELETE FROM dbo.vendedor; 
                DELETE FROM dbo.prenda;                
                DELETE FROM dbo.tienda;
                DBCC CHECKIDENT(vendedor, RESEED, 0)
                DBCC CHECKIDENT(tienda, RESEED, 0)
                DBCC CHECKIDENT(cotizacion, RESEED, 0)
                DBCC CHECKIDENT(prenda, RESEED, 0)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        private IVendedorDTO createSaulGoodman()
        {
            Vendedor v = new Vendedor("Saul", "GoodMan", fakeStore.Id);
            VendedorDaoMySQL dao = new VendedorDaoMySQL(Program.CONNECTION_STRING);
            return dao.save(v);
        }

        private ITiendaDTO createFakeStore()
        {
            Tienda t = new Tienda("FakeStore", "Wonderland", initialStock);
            TiendaDaoMySQL daoStore = new TiendaDaoMySQL(Program.CONNECTION_STRING);
            return daoStore.save(t);
        }

        private void createInitialStock()
        {
            createCamisaMangaCorta();
            createCamisaMangaLarga();
            createPantalonChupin();
            createPantalonComun();
        }

        private void createPantalonComun()
        {
            PantalonBuilder pantalonBuilder = new PantalonBuilder();
            PrendaDirector prendaDirector = new PrendaDirector(pantalonBuilder);
            prendaDirector.addSubType(PrendaSubType.Comun);
            createStandardAndPremium(pantalonBuilder, prendaDirector, 250);
        }

        private void createPantalonChupin()
        {
            PantalonBuilder pantalonBuilder = new PantalonBuilder();
            PrendaDirector prendaDirector = new PrendaDirector(pantalonBuilder);
            prendaDirector.addSubType(PrendaSubType.Chupin);
            createStandardAndPremium(pantalonBuilder, prendaDirector, 750);
        }

        private void createCamisaMangaLarga()
        {
            CamisaBuilder camisaBuilder = new CamisaBuilder();
            PrendaDirector prendaDirector = new PrendaDirector(camisaBuilder);
            prendaDirector.addSubType(PrendaSubType.MangaLarga);
            prendaDirector.addSubType(PrendaSubType.CuelloMao);
            createStandardAndPremium(camisaBuilder, prendaDirector, 75);
            prendaDirector.removeSubType(PrendaSubType.CuelloMao);
            prendaDirector.addSubType(PrendaSubType.CuelloComun);
            createStandardAndPremium(camisaBuilder, prendaDirector, 175);
        }

        private void createCamisaMangaCorta()
        {
            CamisaBuilder camisaBuilder = new CamisaBuilder();
            PrendaDirector prendaDirector = new PrendaDirector(camisaBuilder);
            prendaDirector.addSubType(PrendaSubType.MangaCorta);
            prendaDirector.addSubType(PrendaSubType.CuelloMao);
            createStandardAndPremium(camisaBuilder, prendaDirector, 100);
            prendaDirector.removeSubType(PrendaSubType.CuelloMao);
            prendaDirector.addSubType(PrendaSubType.CuelloComun);
            createStandardAndPremium(camisaBuilder, prendaDirector, 150);
        }

        private void createStandardAndPremium(IPrendaBuilder camisaBuilder, PrendaDirector prendaDirector, int amount)
        {
            PrendaDaoMySQL dao = new PrendaDaoMySQL(Program.CONNECTION_STRING);
            prendaDirector.makeStandard();
            IPrenda prenda = camisaBuilder.getResult();
            prenda.Stock = amount;
            prenda = dao.save(prenda);
            dao.setTienda(fakeStore.Id, prenda);
            initialStock.Add(prenda);

            prendaDirector.makePremium();
            prenda = camisaBuilder.getResult();
            prenda.Stock = amount;
            prenda = dao.save(prenda);
            dao.setTienda(fakeStore.Id, prenda);
            initialStock.Add(prenda);
        }
    }
}
