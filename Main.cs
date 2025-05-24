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
    public partial class Main : Form
    {
        UsersData udata = new UsersData();
        public Main()
        {
            InitializeComponent();
        }
        public Main(string in_username)
        {
            InitializeComponent();
            udata.Connect(in_username);
            username_label.Text = udata.username;
            money_label.Text = udata.money.ToString();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            //search in database
            MessageBox.Show("Hi");
        }

        private void sign_out_button_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
