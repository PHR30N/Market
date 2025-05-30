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

    }
}
