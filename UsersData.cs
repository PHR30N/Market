using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public class UsersData
    {
        public string username;
        public int id;
        public Money money = new Money();
        public UsersData() { }
        public UsersData(string un)     
        {
            this.username = un;
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string selectQuery = "SELECT id,money,discount FROM login WHERE username = @username";

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
                    this.id = reader.GetInt32(0);             // Column 0: id
                    this.money.money = reader.GetInt32(1);    // Column 1: money

                    int dbDiscount = reader.GetInt32(2);      // Column 2: discount
                    reader.Close(); // ✅ Close reader before running update command

                    if (this.id % 5 == 0 && dbDiscount != 5)
                    {
                        this.money.discount = 5;

                        // ✅ Update discount in database only if needed
                        string updateDiscountQuery = "UPDATE login SET discount = @discount WHERE id = @id";
                        using (SqlCommand updateCmd = new SqlCommand(updateDiscountQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@discount", this.money.discount);
                            updateCmd.Parameters.AddWithValue("@id", this.id);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        this.money.discount = dbDiscount;
                    }
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
            if(money.money < amount)
            {
                MessageBox.Show("You don't have enough money!");
                return;
            }
            this.money.UpdateMoney(amount);
            //string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            //string updateQuery = "UPDATE login SET money = @money WHERE id = @id";
            //SqlConnection conn = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand(updateQuery, conn);
            //cmd.Parameters.AddWithValue("@money", this.money.money);
            //cmd.Parameters.AddWithValue("@id", this.id);
            //// Open the connection
            //conn.Open();
            //cmd.ExecuteNonQuery();
            //// Close the connection
            //conn.Close();
        }
        public void Connect(string un)
        {
            this.username = un;
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string selectQuery = "SELECT id,money, discount FROM login WHERE username = @username";
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
                    this.money.money = reader.GetInt32(1);  // Column 1: money
                    this.money.discount = reader.GetInt32(2);
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
            this.money.money = 0;
            this.money.discount = 0;
        }
        public override string ToString()
        {
            return $"Username: {username}, ID: {id}, Money: {money}";
        }

    }
    public class Money
    {
        public int money { set; get; }
        public int discount { set; get; }
        public Money() { }
        public Money(int money, int discount)
        {
            this.money = money;
            this.discount = discount;
        }
        public void UpdateMoney(int amount)
        {
            this.money -= amount - (int)(amount * (discount / 100.0));
        }

    }
}