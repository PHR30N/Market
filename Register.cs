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
    public partial class Register: Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_btn_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string username = register_username.Text;
            string password = register_password.Text;
            string email = register_email.Text;
            string full_name = register_full_name.Text;
            string account_type = register_account_type.Text;
            // check if data is not empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(full_name) || string.IsNullOrEmpty(account_type))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            // check if the username and email is already taken
            string connectionString = "Server=localhost;Database=MarketDB;Integrated Security=True;";
            string checkQuery = "SELECT COUNT(*) FROM login WHERE username = @username OR email = @email";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@username", username);
            checkCmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            int userExists = (int)checkCmd.ExecuteScalar();
            conn.Close();
            if (userExists > 0)
            {
                MessageBox.Show("Username or email already exists.");
                return;
            }
            // Insert the new user into the database
            string insertQuery = "INSERT INTO login (username, password, email, full_name, account_type) VALUES (@username, @password, @email, @full_name, @account_type)";
            SqlConnection insertConn = new SqlConnection(connectionString);
            SqlCommand insertCmd = new SqlCommand(insertQuery, insertConn);
            insertCmd.Parameters.AddWithValue("@username", username);
            insertCmd.Parameters.AddWithValue("@password", password);
            insertCmd.Parameters.AddWithValue("@email", email);
            insertCmd.Parameters.AddWithValue("@full_name", full_name);
            insertCmd.Parameters.AddWithValue("@account_type", account_type);
            // Open the connection
            insertConn.Open();
            // Execute the insert command
            int rowsAffected = insertCmd.ExecuteNonQuery();
            // Close the connection
            insertConn.Close();
            // Check if the insert was successful   
            if (rowsAffected > 0)
            {
                MessageBox.Show("Registration successful!");
                // Optionally, you can redirect the user to the login form or another form
                this.Close(); // Close the registration form
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        private void register_show_password_CheckedChanged(object sender, EventArgs e)
        {
            //if the checkbox is checked, show the password
            if (register_show_password.Checked)
            {
                register_password.UseSystemPasswordChar = false;
            }
            else
            {
                register_password.UseSystemPasswordChar = true;
            }
        }
    }
}
