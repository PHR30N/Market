using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        string myConnectionString = "Data Source=localhost;Initial Catalog=MarketDB;Integrated Security=True;TrustServerCertificate=True";
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
        public void LoadCategoryItems(string connectionString, FlowLayoutPanel flowPanel)
        {
            string tableName = null;

            // Identify which table to query based on selected radio button
            if (phones_radioButton.Checked) tableName = "Phones";
            else if (fold_radioButton.Checked) tableName = "Folds";
            else if (laptop_radioButton.Checked) tableName = "Laptops";
            else if (gaming_laptop_radioButton.Checked) tableName = "GammingLaptops";
            else if (two_in_one_radioButton.Checked) tableName = "TwoInOnes";
            else if (cpu_radioButton.Checked) tableName = "Cpus";
            else if (gpu_radioButton.Checked) tableName = "Gpus";
            else return; // No category selected

            string query = $"SELECT id, name, image FROM {tableName}";

            List<(int Id, string Name, byte[] ImageBytes)> items = new List<(int Id, string Name, byte[] ImageBytes)>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = reader["name"].ToString();
                        byte[] image = reader["image"] != DBNull.Value ? (byte[])reader["image"] : null;

                        items.Add((id, name, image));
                    }
                }
            }

            // Clear the panel
            flowPanel.Controls.Clear();

            // Create UI for each item
            foreach (var item in items)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(100, 100),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = item.ImageBytes != null ? ByteArrayToImage(item.ImageBytes) : null,
                    Location = new Point(25, 20)
                };

                LinkLabel linkLabel = new LinkLabel
                {
                    Text = item.Name,
                    AutoSize = true,
                    Location = new Point((150 - TextRenderer.MeasureText(item.Name, new Font("Arial", 8)).Width) / 2, pictureBox.Bottom + 5)
                };

                linkLabel.Click += (s, e) =>
                {
                    MessageBox.Show($"You clicked on {item.Name} (ID: {item.Id})");
                    Form1 form1 = new Form1(_loginForm,item.Name,tableName);
                    this.Close();
                    form1.Show();
                };

                GroupBox groupBox = new GroupBox
                {
                    Size = new Size(150, 160),
                    BackColor = Color.White,
                    Text = $"{tableName} #{item.Id}"
                };

                groupBox.Controls.Add(pictureBox);
                groupBox.Controls.Add(linkLabel);

                flowPanel.Controls.Add(groupBox);
            }
        }

        public Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void phones_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCategoryItems(myConnectionString, flowLayoutPanel);
        }

        private void fold_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCategoryItems(myConnectionString, flowLayoutPanel);
        }

        private void laptop_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCategoryItems(myConnectionString, flowLayoutPanel);
        }

        private void gaming_laptop_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCategoryItems(myConnectionString, flowLayoutPanel);
        }

        private void two_in_one_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCategoryItems(myConnectionString, flowLayoutPanel);
        }

        private void cpu_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCategoryItems(myConnectionString, flowLayoutPanel);
        }

        private void gpu_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCategoryItems(myConnectionString, flowLayoutPanel);
        }
    }
}
