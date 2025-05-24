using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    class UsersData
    {
        public string username;
        public int id;
        public int money;
        public UsersData() { }
        public UsersData(string un)     
        {
            this.username = un;
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string selectQuery = "SELECT id,money FROM login WHERE username = @username";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@username", un);
            SqlDataReader reader = null;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    this.id = reader.GetInt32(0);     // Column 0: id
                    this.money = reader.GetInt32(1);  // Column 1: money
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public void UpdateMoney(int amount)
        {
            this.money += amount;
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string updateQuery = "UPDATE login SET money = @money WHERE id = @id";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@money", this.money);
            cmd.Parameters.AddWithValue("@id", this.id);
            // Open the connection
            conn.Open();
            cmd.ExecuteNonQuery();
            // Close the connection
            conn.Close();
        }
        public void Connect(string un)
        {
            this.username = un;
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string selectQuery = "SELECT id,money FROM login WHERE username = @username";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@username", un);
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    this.id = reader.GetInt32(0);     // Column 0: id
                    this.money = reader.GetInt32(1);  // Column 1: money
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            finally
            {
                if (reader != null) reader.Close();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public void Disconnect()
        {
            // This method can be used to clean up resources if needed.
            // In this case, we don't have any persistent connections to close.
            this.username = null;
            this.id = 0;
            this.money = 0;
        }
        public override string ToString()
        {
            return $"Username: {username}, ID: {id}, Money: {money}";
        }

    }
}
