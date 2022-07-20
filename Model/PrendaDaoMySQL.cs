using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ExamenModuloC.Model
{
    internal class PrendaDaoMySQL : Interface.IPrendaDAO
    {
        private String connectionString;

        public PrendaDaoMySQL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "DELETE FROM prenda WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = id;
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }
        public IPrenda get(int id)
        {
            int prendaId = 0;
            string? json = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM prenda WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = id;
                SqlDataReader registers = cmd.ExecuteReader();
                registers.Read();
                if (registers != null && registers.HasRows)
                {
                    String? buffer;
                    if (registers["id"] != null)
                    {
                        //Maybe a little bit overkill, we could safely assume that the db wont have null ids..
                        buffer = registers["id"].ToString();
                        if (buffer != null)
                            prendaId = Int32.Parse(buffer);
                    }
                    json = registers["prenda"].ToString();
                }
                connection.Close();
            }
            if (json == null)
                json = "";
            IPrenda prenda = System.Text.Json.JsonSerializer.Deserialize<IPrenda>(json);
            if (prenda == null)
            {
                throw new Exceptions.NoSuchPrendaException();
            }
            return prenda;
        }
        public IPrenda save(IPrenda prenda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "INSERT INTO prenda(prenda) OUTPUT inserted.id VALUES (@json)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@json", System.Data.SqlDbType.NVarChar);
                cmd.Parameters["@json"].Value = System.Text.Json.JsonSerializer.Serialize(prenda);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                if (prenda.Type.TypeOfPrenda == Enums.PrendaType.Camisa)
                {
                    return new Prendas.Camisa(newId, prenda);
                } 
                else
                {
                    return new Prendas.Pantalon(newId, prenda);
                }
            }
        }
        public bool update(IPrenda prenda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "UPDATE prenda SET prenda = @json WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters.Add("@json", System.Data.SqlDbType.NChar);
                cmd.Parameters["@id"].Value = prenda.Id;
                cmd.Parameters["@json"].Value = System.Text.Json.JsonSerializer.Serialize(prenda);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public void setTienda(int idTienda, IPrenda prenda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "UPDATE prenda SET idTienda = @idTienda WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters.Add("@idTienda", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = prenda.Id;
                cmd.Parameters["@idTienda"].Value = idTienda;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
