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
using static Market.Fold;

namespace Market
{
    public partial class Form1 : Form
    {
        protected Form _loginForm;
        string myConnectionString = "Data Source=localhost;Initial Catalog=MarketDB;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
            admin_phone_groupbox.Hide();
            fold_groupbox.Hide();
            admin_laptop_groupbox.Hide();
            gaming_laptop_groupbox.Hide();
            admin_two_in_one_laptop_groupbox.Hide();
            admin_cpu_groupbox.Hide();
            gpu_groupbox.Hide();
        }
        public Form1(Form login)
        {
            InitializeComponent();
            admin_phone_groupbox.Hide();
            fold_groupbox.Hide();
            admin_laptop_groupbox.Hide();
            gaming_laptop_groupbox.Hide();
            admin_two_in_one_laptop_groupbox.Hide();
            admin_cpu_groupbox.Hide();
            gpu_groupbox.Hide();
            _loginForm = login;

        }
        public Form1(Form login, string in_name, string type)
        {
            InitializeComponent();
            admin_phone_groupbox.Hide();
            fold_groupbox.Hide();
            admin_laptop_groupbox.Hide();
            gaming_laptop_groupbox.Hide();
            admin_two_in_one_laptop_groupbox.Hide();
            admin_cpu_groupbox.Hide();
            gpu_groupbox.Hide();
            _loginForm = login;
            object myDeviceInstance;

            if (type == "Phones")
            {
                myDeviceInstance = new Phone();
                admin_phone_groupbox.Show();
            }
            else if (type == "Folds")
            {
                myDeviceInstance = new Fold();
                admin_phone_groupbox.Show();
                fold_groupbox.Show();
            }
            else if (type == "GammingLaptops")
            {
                myDeviceInstance = new GamingLaptop();
                admin_laptop_groupbox.Show();
                gaming_laptop_groupbox.Show();
            }
            else if (type == "TwoInOnes")
            {
                myDeviceInstance = new TwoInOne();
                admin_laptop_groupbox.Show();
                admin_two_in_one_laptop_groupbox.Show();
            }
            else if (type == "Laptops")
            {
                myDeviceInstance = new Laptop();
                admin_laptop_groupbox.Show();
            }
            else if (type == "Cpus")
            {
                myDeviceInstance = new Cpu();
                admin_cpu_groupbox.Show();
            }
            else if (type == "Gpus")
            {
                myDeviceInstance = new Gpu();
                gpu_groupbox.Show();
            }
            else
                throw new InvalidOperationException("No device type selected.");

            // Call dynamic GetData
            ((Electronics)myDeviceInstance).GetData(in_name, myConnectionString);

            // Now update the UI from myDeviceInstance
            FillUIWithDeviceData(myDeviceInstance);
        }
        private void FillUIWithDeviceData(object device)
        {
            if (device is Electronics e)
            {
                name.Text = e.name;
                brand.Text = e.brand;
                model.Text = e.model;
                color.Text = e.color;
                price.Value = (decimal)e.price;
                description.Text = e.description;
                quantity.Value = e.quantity;
                qrcode.Text = e.QRCode;

                if (e.image != null)
                {
                    using (MemoryStream ms = new MemoryStream(e.image))
                    {
                        admin_pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }

            if (device is Phone p)
            {
                admin_phone_os.Text = p.operatingSystem;
                admin_phone_screen_size.Value = (decimal)p.screenSize;
                admin_phone_storage.Value = p.storageCapacity;
                admin_ram_size.Value = p.ramSize;
                admin_phone_camera.Value = p.cameraQuality;
                admin_phone_cpu.Text = p.cpuType;
                admin_phone_battery.Value = p.batteryCapacity;
                admin_tablet.Checked = p.tablet;
            }

            if (device is Fold f)
            {
                admin_fold_type.Text = f.foldType;
                admin_hinge_type_type.Text = f.hingeMaterial;
                admin_display_type_type.Text = f.displayType;
                admin_durability_rating_type.Text = f.durabilityRating;
                admin_size_of_opened_screen_type.Value = (decimal)f.sizeOfOpenedScreen;
            }

            if (device is Laptop l)
            {
                admin_os.Text = l.operatingSystem;
                admin_storage.Value = l.storageCapacity;
                admin_ram.Value = l.ramSize;
                admin_gpu.Text = l.graphicsCard;
                admin_cpu.Text = l.cpuType;
                admin_screen_size.Value = (decimal)l.screenSize;
                admin_battery_life.Value = decimal.TryParse(l.batteryLife, out var bl) ? bl : 0;
            }

            if (device is GamingLaptop gl)
            {
                admin_cooling_system.Text = gl.coolingSystem;
                admin_keyboard_type.Text = gl.keyboardType;
                admin_frame_rate.Text = gl.frameRate.ToString();
            }

            if (device is TwoInOne t)
            {
                admin_detachable_keyboard_checkBox.Checked = t.detachableKeyboard;
                admin_hinge_type.Text = t.hingeType;
            }

            if (device is Cpu c)
            {
                admin_cores.Value = c.cores;
                admin_frequency_ghz.Value = (decimal)c.frequencyGHz;
                admin_socket_type.Text = c.socketType;
            }

            if (device is Gpu g)
            {
                memory_gb.Value = g.memoryGB;
                chipset.Text = g.chipset;
            }
        }


        private void login_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Close();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            _loginForm.Close();
            this.Close();
        }

        private void gpu_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gpu_radioButton.Checked)
            {

                admin_cpu_groupbox.Hide();
                admin_phone_groupbox.Hide();
                fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                gpu_groupbox.Show();
            }
        }

        private void phones_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (phones_radioButton.Checked)
            {
                admin_phone_groupbox.Show();
                fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                phones_radio_groupbox.Show();
                laptop_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                gpu_groupbox.Hide();
                fold_radioButton.Checked = false;
            }
        }

        private void fold_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fold_radioButton.Checked)
            {
                fold_groupbox.Show();
                admin_phone_groupbox.Show();
                admin_laptop_groupbox.Hide();
                gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                gpu_groupbox.Hide();
            }
        }

        private void laptop_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (laptop_radioButton.Checked)
            {

                admin_phone_groupbox.Hide();
                fold_groupbox.Hide();
                gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                gpu_groupbox.Hide();
                admin_laptop_groupbox.Show();
                // Ensure the main laptop groupbox is visible and sub-groupboxes are hidden
                // Uncheck subcategory radio buttons to reset state
                gaming_laptop_radioButton.Checked = false;
                two_in_one_radioButton.Checked = false;
            }
        }

        private void cpu_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (cpu_radioButton.Checked)
            {

                gpu_groupbox.Hide();
                admin_phone_groupbox.Hide();
                fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_cpu_groupbox.Show();
            }
        }

        private void gaming_laptop_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gaming_laptop_radioButton.Checked)
            {
                admin_laptop_groupbox.Show();
                gaming_laptop_groupbox.Show();
                admin_phone_groupbox.Hide();
                fold_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                gpu_groupbox.Hide();
            }
        }

        private void two_in_one_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (two_in_one_radioButton.Checked)
            {

                admin_two_in_one_laptop_groupbox.Show();
                admin_phone_groupbox.Hide();
                fold_groupbox.Hide();
                gaming_laptop_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                gpu_groupbox.Hide();
                admin_laptop_groupbox.Show();
            }
        }

        private void search_Click_1(object sender, EventArgs e)
        {
            string searchValue = search_textBox.Text;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please fill in search value.");
                return;
            }

            object myDeviceInstance;

            if (phones_radioButton.Checked)
                myDeviceInstance = new Phone();
            else if (fold_radioButton.Checked)
                myDeviceInstance = new Fold();
            else if (gaming_laptop_radioButton.Checked)
                myDeviceInstance = new GamingLaptop();
            else if (two_in_one_radioButton.Checked)
                myDeviceInstance = new TwoInOne();
            else if (laptop_radioButton.Checked)
                myDeviceInstance = new Laptop();
            else if (cpu_radioButton.Checked)
                myDeviceInstance = new Cpu();
            else if (gpu_radioButton.Checked)
                myDeviceInstance = new Gpu();
            else
                throw new InvalidOperationException("No device type selected.");

            // Call dynamic GetData
            ((Electronics)myDeviceInstance).GetData(searchValue, myConnectionString);

            // Now update the UI from myDeviceInstance
            FillUIWithDeviceData(myDeviceInstance); // <- Make this a method to update all fields accordingly
        }
    }
}
