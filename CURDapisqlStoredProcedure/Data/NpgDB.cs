using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace CURDapisqlStoredProcedure.Data
{
    public class NpgDB
    {

        public bool SaveProduct(string name, double price)
        {
            bool saved = false;
            using (var cn = GetConnection ())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("call save_product(:p_name, :p_price)", cn);
                cmd.Parameters.AddWithValue("p_name", DbType.String).Value = name;
                cmd.Parameters.AddWithValue("p_price", DbType.Double).Value = price;
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int affectedCount = cmd.ExecuteNonQuery();
                saved = affectedCount == 1;
            }
            return saved;

        }

        public bool UpdateProduct(int id, string name, double price)
        {
            bool updated = false;
            using (var cn = GetConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("call update_product(:p_name, :p_price, :p_id)", cn);
                cmd.Parameters.AddWithValue("p_name", DbType.String).Value = name;
                cmd.Parameters.AddWithValue("p_price", DbType.Double).Value = price;
                cmd.Parameters.AddWithValue("p_id", DbType.Int32).Value = id;
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int affectedCount = cmd.ExecuteNonQuery();
                updated = affectedCount == 1;
            }
            return updated;

        }

        public bool DeleteProduct(int id)
        {
            bool deleted = false;
            using (var cn = GetConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("call delete_product(:p_name, :p_price, :p_id)", cn);
               cmd.Parameters.AddWithValue("p_id", DbType.Int32).Value = id;
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int affectedCount = cmd.ExecuteNonQuery();
                deleted = affectedCount == 1;
            }
            return deleted;

        }

        private NpgsqlConnection GetConnection()
        {

            return new NpgsqlConnection("Host=localhost;Port=5432;User ID=postgres; Password=password;Database=postgres;Pooling=true;");
        }
    }
}
