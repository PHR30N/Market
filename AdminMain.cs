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
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
            admin_phone_groupbox.Hide();
            admin_fold_groupbox.Hide();
            admin_laptop_groupbox.Hide();
            admin_gaming_laptop_groupbox.Hide();
            admin_two_in_one_laptop_groupbox.Hide();
            admin_phones_radio_groupbox.Hide();
            admin_laptop_radio_groupbox.Hide();
            admin_cpu_groupbox.Hide();
            admin_gpu_groupbox.Hide();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void close_button_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void admin_phones_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_phones_radioButton.Checked)
            {
                admin_phone_groupbox.Show();
                admin_fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Show();
                admin_laptop_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                admin_gpu_groupbox.Hide();
                admin_fold_radioButton.Checked = false;
            }
        }

        private void admin_laptop_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_laptop_radioButton.Checked)
            {
                admin_laptop_groupbox.Show();
                admin_laptop_radio_groupbox.Show();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                admin_gpu_groupbox.Hide();

                // Ensure the main laptop groupbox is visible and sub-groupboxes are hidden
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();

                // Uncheck subcategory radio buttons to reset state
                admin_gaming_laptop_radioButton.Checked = false;
                admin_two_in_one_radioButton.Checked = false;
            }
        }

        private void admin_cpu_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_cpu_radioButton.Checked)
            {
                admin_cpu_groupbox.Show();
                admin_gpu_groupbox.Hide();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_laptop_radio_groupbox.Hide();
            }
        }

        private void admin_gpu_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_gpu_radioButton.Checked)
            {
                admin_gpu_groupbox.Show();
                admin_cpu_groupbox.Hide();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_laptop_radio_groupbox.Hide();
            }
        }

        private void admin_fold_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_fold_radioButton.Checked)
            {
                admin_fold_groupbox.Show();
                admin_phone_groupbox.Show();
                admin_laptop_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Show();
                admin_laptop_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                admin_gpu_groupbox.Hide();
            }
        }

        private void admin_gaming_laptop_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_gaming_laptop_radioButton.Checked)
            {
                admin_laptop_groupbox.Show();
                admin_gaming_laptop_groupbox.Show();
                admin_laptop_radio_groupbox.Show();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                admin_gpu_groupbox.Hide();
            }
        }

        private void admin_two_in_one_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_two_in_one_radioButton.Checked)
            {
                admin_laptop_groupbox.Show();
                admin_two_in_one_laptop_groupbox.Show();
                admin_laptop_radio_groupbox.Show();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                admin_gpu_groupbox.Hide();
            }
        }

        private void admin_add_Click(object sender, EventArgs e)
        {
            string myConnectionString = "Data Source=localhost;Initial Catalog=MarketDB;Integrated Security=True;TrustServerCertificate=True";
            Phone myPhone = new Phone(
             name: admin_name.Text,
             brand: admin_brand.Text,
             model: admin_model.Text,
             color: admin_color.Text,
             price: (float)admin_price.Value,
             description: admin_description.Text,
             quantity: (int)admin_quantity.Value,
             imagePath: admin_image_path.Text,
             qrCode: admin_qrcode.Text,
             operatingSystem: admin_phone_os.Text,
             screenSize: (float)admin_phone_screen_size.Value,
             storageCapacity: (int)admin_phone_storage.Value,
             ramSize: (int)admin_ram_size.Value,
             cameraQuality: (int)admin_phone_camera.Value,
             cpuType: admin_phone_cpu.Text,
             batteryCapacity: (int)admin_phone_battery.Value,
             tablet: admin_tablet.Checked
             );

            myPhone.SaveToDbAsync(myConnectionString);
            MessageBox.Show("Phone saved!");
        }
    }
}
