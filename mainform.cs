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
    public partial class mainform: Form
    {
        private Form _loginForm;
        public string in_username { get; set; }
        public mainform()
        {
            InitializeComponent();
        }
        public mainform(string in_username)
        {
            InitializeComponent();
        }
        public mainform(string in_username, Login login)
        {
            InitializeComponent();
            _loginForm = login;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.Close();
        }

        private void login_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.Show();
        }
    }
}
