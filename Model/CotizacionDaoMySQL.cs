using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.Json.Nodes;

namespace ExamenModuloC.Model
{
    internal class CotizacionDaoMySQL : Interface.ICrudDao<ICotizacionDTO>
    {
        private String connectionString;

        public CotizacionDaoMySQL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "DELETE FROM cotizacion WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = id;
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public ICotizacionDTO get(int id)
        {
            int cotizacionId = 0;
            DateTime dateTime = DateTime.MinValue;
            int idVendedor = 0;
            string json = "";
            int amount = -1;
            double total = -1;
            IPrenda? item;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM cotizacion WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = id;
                SqlDataReader registers = cmd.ExecuteReader();
                registers.Read();
                if (registers != null && registers.HasRows)
                {
                    String? buffer;
                    cotizacionId = id;
                    buffer = registers["dateTime"].ToString();
                    dateTime = Convert.ToDateTime(registers["dateTime"]);

                    buffer = registers["prenda"].ToString();
                    if (buffer != null)
                        json = buffer;
                    buffer = registers["amount"].ToString();
                    if (buffer != null)
                        amount = Int32.Parse(buffer);
                    buffer = registers["total"].ToString();
                    if (buffer != null)
                        total = Double.Parse(buffer);
                }
                JsonNode jsonObject = JsonNode.Parse(registers["prenda"].ToString());
                item = Presenter.Utils.PrendaFactory.getPrendaFromJson(jsonObject);
            }
            if (item == null)
                throw new Exceptions.NoSuchPrendaException();
            return new Cotizacion(id, dateTime, idVendedor, item, amount, total);
        }

        public ICotizacionDTO save(ICotizacionDTO cotizacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "INSERT INTO cotizacion(dateTime,idVendedor,prenda,amount,total) OUTPUT inserted.id VALUES (@dateTime,@idVendedor,@prenda,@amount,@total)";
                SqlCommand cmd = new SqlCommand(query, connection);
                parseQueryWithTiendaDTO(cotizacion, cmd);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                return new Cotizacion(newId, cotizacion.DateTime, cotizacion.IdVendedor, cotizacion.Item, cotizacion.ItemAmount, cotizacion.Total);
            }
        }
        public bool update(ICotizacionDTO cotizacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "UPDATE cotizacion SET dateTime = @dateTime, idVendedor = @idVendedor, prenda = @prenda, amount = @amount, total = @total WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                parseQueryWithTiendaDTO(cotizacion, cmd);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }

        }

        public List<ICotizacionDTO> getCotizacionesFromVendedor(IVendedorDTO vendedorId)
        {
            List<Int64> cotizacionIds = new List<Int64>();
            List<ICotizacionDTO> cotizaciones = new List<ICotizacionDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT id FROM cotizacion WHERE idVendedor = @idVendedor";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@idVendedor", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@idVendedor"].Value = vendedorId.Id;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    cotizacionIds.Add(Int64.Parse(reader["id"].ToString()));
                }
            }
            foreach(int cotizacionId in cotizacionIds)
            {
                cotizaciones.Add(this.get(cotizacionId));
            }
            return cotizaciones;
        }
        private void parseQueryWithTiendaDTO(ICotizacionDTO cotizacion, SqlCommand cmd)
        {
            cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
            cmd.Parameters.Add("@dateTime", System.Data.SqlDbType.DateTime);
            cmd.Parameters.Add("@idVendedor", System.Data.SqlDbType.BigInt);
            cmd.Parameters.Add("@prenda", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@amount", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@total", System.Data.SqlDbType.Float);
            cmd.Parameters["@id"].Value = cotizacion.Id;
            cmd.Parameters["@dateTime"].Value = cotizacion.DateTime;
            cmd.Parameters["@idVendedor"].Value = cotizacion.IdVendedor;
            cmd.Parameters["@prenda"].Value = System.Text.Json.JsonSerializer.Serialize(cotizacion.Item);
            cmd.Parameters["@amount"].Value = cotizacion.ItemAmount;
            cmd.Parameters["@total"].Value = cotizacion.Total;
        }
    }
}
