using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (username == "youssef" && password == "1234")
            {
                MessageBox.Show("Login successful!");
                // Open the main form or perform any other action
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
