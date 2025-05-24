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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if(login_forgot_your_password.Checked)
            {
                //select username and email then check
                //if exists login
                //else show message
                string username1 = login_username.Text;
                string email = login_email.Text;
                string connectionString1 = "Server=localhost;Database=MarketDB;Integrated Security=True;";
                string selectQuery1 = "SELECT COUNT(*) FROM login WHERE username = @username AND email = @email";
                SqlConnection conn1 = new SqlConnection(connectionString1);
                SqlCommand cmd1 = new SqlCommand(selectQuery1, conn1);
                // Open the connection
                conn1.Open();
                // Add parameters to avoid SQL injection
                cmd1.Parameters.AddWithValue("@username", username1);
                cmd1.Parameters.AddWithValue("@email", email);
                // Execute the query and get the count of matching records
                int userExists1 = (int)cmd1.ExecuteScalar();
                // Close the connection
                conn1.Close();
                // Check if user exists
                if (userExists1 > 0)
                {
                    //MessageBox.Show("Login successful!");
                    this.Hide();
                    Main main = new Main(username1);
                    main.Show();
                    // Open the main form or perform any other action
                }
                else
                {
                    MessageBox.Show("Invalid username or email.");
                }
                return;
            }
            string username = login_username.Text;
            string password = login_password.Text;
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
                //MessageBox.Show("Login successful!");
                this.Hide();
                Main main = new Main(username);
                main.Show();
                // Open the main form or perform any other action
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void login_create_new_account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void login_forgot_your_password_CheckedChanged(object sender, EventArgs e)
        {
            if (login_forgot_your_password.Checked)
            {
                login_password.Hide();
                login_password_label.Hide();
            }
            if(!login_forgot_your_password.Checked)
            {
                login_password.Show();
                login_password_label.Show();
            }
        }

        // Pseudocode:
        // 1. Ensure the login_password TextBox property 'UseSystemPasswordChar' is set to true by default in the designer.
        // 2. In the CheckedChanged event for login_show_password, toggle UseSystemPasswordChar.
        // 3. Make sure the event handler is correctly assigned to the CheckBox in the designer or in code.
        // 4. If using PasswordChar instead of UseSystemPasswordChar, set PasswordChar = '\0' to show plain text.

        private void login_show_password_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            
            if(login_show_password.Checked)
                login_password.UseSystemPasswordChar = false;
            if (!login_show_password.Checked)
                login_password.UseSystemPasswordChar = true;
        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {
            login_password.UseSystemPasswordChar = true;
            if (login_show_password.Checked)
                login_password.UseSystemPasswordChar = false;
            if (!login_show_password.Checked)
                login_password.UseSystemPasswordChar = true;
        }
    }
}
