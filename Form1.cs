using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string selectQuery = "SELECT COUNT(*) FROM login WHERE username = @username AND password = @password";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectQuery, conn);

            // Open the connection
            conn.Open();

            // Add parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            // Execute the query and get the count of matching records
            int userExists = (int)cmd.ExecuteScalar();

            // Close the connection
            conn.Close();

            // Check if user exists
            if (userExists > 0)
            {
                MessageBox.Show("Login successful!");
                // Open the main form or perform any other action
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
            //the code bellow is for inserting data into the database, for register form
            /*
            string username = Username.Text;
            string password = Password.Text;
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string insertQuery = "INSERT INTO login (username, password) VALUES (@username, @password)";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(insertQuery, conn);

            // Open the connection
            conn.Open();

            // Add parameters
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            // Execute the query 
            cmd.ExecuteNonQuery();

            // Close the connection
            conn.Close();
            if (username == "Mohamed" && password == "1234")
            {

                MessageBox.Show("Login successful!");
                // Open the main form or perform any other action
            }
            else
            {
                    MessageBox.Show("Invalid username or password.");
            }*/
        }
    }
}
