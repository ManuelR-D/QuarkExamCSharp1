using ExamenModuloC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ExamenModuloC.Model
{
    internal class VendedorDaoMySQL : Interface.ICrudDao<IVendedorDTO>
    {
        private String connectionString;

        public VendedorDaoMySQL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "DELETE FROM vendedor WHERE id = (@id)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = id;
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public IVendedorDTO get(int id)
        {
            int sellerId = 0;
            int workId = 0;
            string? name = "";
            string? lastName = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM vendedor WHERE id = (@id)";
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
                        //Maybe a little bit overkill, maybe we should safely assume that the db wont have null ids..
                        buffer = registers["id"].ToString();
                        if (buffer != null)
                            sellerId = Int32.Parse(buffer);
                    }
                    name = registers["name"].ToString();
                    lastName = registers["lastName"].ToString();
                    if (registers["workplaceId"] != null)
                    {
                        //Maybe a little bit overkill, maybe we should safely assume that the db wont have null ids..
                        buffer = registers["workplaceId"].ToString();
                        if (buffer != null)
                            workId = Int32.Parse(buffer);
                    }

                }
                connection.Close();
            }
            return new Vendedor(sellerId, name, lastName, workId);
        }

        public IVendedorDTO save(IVendedorDTO vendedorDTO)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "INSERT INTO vendedor(name,lastName,workplaceId) OUTPUT inserted.id VALUES (@name,@lastName,@workplaceId)";
                SqlCommand cmd = new SqlCommand(query, connection);
                parseQueryWithVendedorDTO(vendedorDTO, cmd);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                Vendedor v = (Vendedor)vendedorDTO;
                v.Id = newId;
                return v;
            }
        }
        public bool update(IVendedorDTO updatedVendedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "UPDATE vendedor SET name = @name, lastName = @lastName WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                parseQueryWithVendedorDTO(updatedVendedor, cmd);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        private static void parseQueryWithVendedorDTO(IVendedorDTO vendedorDTO, SqlCommand cmd)
        {
            cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@workplaceId", System.Data.SqlDbType.BigInt);
            cmd.Parameters["@id"].Value = vendedorDTO.Id;
            cmd.Parameters["@name"].Value = vendedorDTO.Name;
            cmd.Parameters["@lastName"].Value = vendedorDTO.LastName;
            cmd.Parameters["@workplaceId"].Value = vendedorDTO.WorkplaceId;
        }
    }
}
