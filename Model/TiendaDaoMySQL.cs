using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExamenModuloC.Model.Prendas;
using System.Text.Json.Nodes;

namespace ExamenModuloC.Model
{
    internal class TiendaDaoMySQL : Interface.ICrudDao<ITiendaDTO>
    {
        private String connectionString;

        public TiendaDaoMySQL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "DELETE FROM tienda WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = id;
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public ITiendaDTO get(int id)
        {
            int sellerId = 0;
            string? name = "";
            string? address = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM tienda WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = id;
                SqlDataReader registers = cmd.ExecuteReader();
                registers.Read();
                if(registers != null && registers.HasRows)
                {
                    String? buffer;
                    if (registers["id"] != null)
                    {
                        //Maybe a little bit overkill, we could safely assume that the db wont have null ids..
                        buffer = registers["id"].ToString();
                        if (buffer != null)
                            sellerId = Int32.Parse(buffer);
                    }
                    name = registers["name"].ToString();
                    address = registers["address"].ToString();
                }
                connection.Close();
            }
            if (name == null)
                name = "";
            if (address == null)
                address = "";
            return new Tienda(sellerId, name, address, null);
        }

        public ITiendaDTO save(ITiendaDTO tiendaDTO)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "INSERT INTO tienda(name,address) OUTPUT inserted.id VALUES (@name,@address)";
                SqlCommand cmd = new SqlCommand(query, connection);
                parseQueryWithTiendaDTO(tiendaDTO, cmd);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                Tienda t = (Tienda)tiendaDTO;
                t.Id = newId;
                return t;
            }
        }
        public bool update(ITiendaDTO updatedTienda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "UPDATE vendedor SET name = @name, address = @address WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                parseQueryWithTiendaDTO(updatedTienda, cmd);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public void getItems(ITiendaDTO tienda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM prenda WHERE idTienda = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = tienda.Id;
                SqlDataReader registers = cmd.ExecuteReader();
                while(registers.Read())
                {
                    JsonNode jsonObject = JsonNode.Parse(registers["prenda"].ToString());
                    jsonObject["Id"] = Int32.Parse(registers["id"].ToString());
                    //Camisa c;
                    tienda.Items.Add(Presenter.Utils.PrendaFactory.getPrendaFromJson(jsonObject));
                }
            }
        }

        private static void parseQueryWithTiendaDTO(ITiendaDTO tiendaDTO, SqlCommand cmd)
        {
            cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar, 50);
            cmd.Parameters["@id"].Value = tiendaDTO.Id;
            cmd.Parameters["@name"].Value = tiendaDTO.Name;
            cmd.Parameters["@address"].Value = tiendaDTO.Address;
        }
    }
}
