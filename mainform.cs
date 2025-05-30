using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class mainform: Form
    {
        private Form _loginForm;
        public GroupBox CloneGroupBoxWithPictureAndLink(GroupBox originalGroupBox, Image image, string linkText)
        {
            // Create the new GroupBox and copy basic properties
            GroupBox clone = new GroupBox
            {
                Size = originalGroupBox.Size,
                Text = originalGroupBox.Text,
                BackColor = originalGroupBox.BackColor,
                ForeColor = originalGroupBox.ForeColor,
                Font = originalGroupBox.Font
            };

            // Create the PictureBox
            PictureBox pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(100, 100), // Adjust size as needed
            };

            // Center the PictureBox
            pictureBox.Location = new Point(
                (clone.Width - pictureBox.Width) / 2,
                (clone.Height - pictureBox.Height) / 2 - 20 // shift upward to make room for link below
            );

            // Create the LinkLabel
            LinkLabel linkLabel = new LinkLabel
            {
                Text = linkText,
                AutoSize = true
            };

            // Center the LinkLabel under the PictureBox
            linkLabel.Location = new Point(
                (clone.Width - linkLabel.PreferredWidth) / 2,
                pictureBox.Bottom + 5
            );

            // Optional: Add click event for the link
            linkLabel.Click += (sender, e) =>
            {
                MessageBox.Show("Link clicked!");
            };

            // Add controls to the cloned GroupBox
            clone.Controls.Add(pictureBox);
            clone.Controls.Add(linkLabel);

            return clone;
        }
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

        private void admin_search_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(_loginForm);
            form.Show();
            this.Close();
        }
    }
}
