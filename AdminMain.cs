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
    public partial class AdminMain : Form
    {
        private Form _loginForm;
        string myConnectionString = "Data Source=localhost;Initial Catalog=MarketDB;Integrated Security=True;TrustServerCertificate=True";
        private byte[] uploadedImageBytes = null; 
        
        public static void SetPropertiesFromDictionary(object target, Dictionary<string, object> values)
        {
            var targetType = target.GetType();
            foreach (var kvp in values)
            {
                var property = targetType.GetProperty(kvp.Key);
                if (property != null && property.CanWrite)
                {
                    var value = kvp.Value;
                    if (value != null && property.PropertyType != value.GetType())
                    {
                        value = Convert.ChangeType(value, property.PropertyType);
                    }
                    property.SetValue(target, value);
                }
            }
        }
        public Dictionary<string, object> BuildFinalDictionary()
        {
            var finalData = new Dictionary<string, object>();

            var electronicsData = new Dictionary<string, object>
            {
                { "name", admin_name.Text },
                { "brand", admin_brand.Text },
                { "model", admin_model.Text },
                { "color", admin_color.Text },
                { "price", (float)admin_price.Value },
                { "description", admin_description.Text },
                { "quantity", (int)admin_quantity.Value },
                { "image", uploadedImageBytes },
                { "QRCode", admin_qrcode.Text }
            };

            var phoneData = new Dictionary<string, object>
            {
                { "operatingSystem", admin_phone_os.Text },
                { "screenSize", (float)admin_phone_screen_size.Value },
                { "storageCapacity", (int)admin_phone_storage.Value },
                { "ramSize", (int)admin_ram_size.Value },
                { "cameraQuality", (int)admin_phone_camera.Value },
                { "cpuType", admin_phone_cpu.Text },
                { "batteryCapacity", (int)admin_phone_battery.Value },
                { "tablet", admin_tablet.Checked }
            };

            var foldData = new Dictionary<string, object>
            {
                { "foldType", admin_fold_type.Text },
                { "hingeMaterial", admin_hinge_type_type.Text },
                { "displayType", admin_display_type_type.Text },
                { "durabilityRating", admin_durability_rating_type.Text },
                { "sizeOfOpenedScreen", (float)admin_size_of_opened_screen_type.Value }
            };

            var laptopData = new Dictionary<string, object>
            {
                { "operatingSystem", admin_os.Text },
                { "storageCapacity", (int)admin_storage.Value },
                { "ramSize", (int)admin_ram.Value },
                { "graphicsCard", admin_gpu.Text },
                { "cpuType", admin_cpu.Text },
                { "screenSize", (float)admin_screen_size.Value },
                { "batteryLife", admin_battery_life.Value.ToString() }
            };

            var gamingLaptopData = new Dictionary<string, object>
            {
                { "coolingSystem", admin_cooling_system.Text },
                { "keyboardType", admin_keyboard_type.Text },
                { "frameRate", (int)admin_frame_rate.Value }
            };

            var twoInOneData = new Dictionary<string, object>
            {
                { "detachableKeyboard", admin_detachable_keyboard_checkBox.Checked },
                { "hingeType", admin_hinge_type.Text }
            };

            var cpuData = new Dictionary<string, object>
            {
                { "cores", (int)admin_cores.Value },
                { "frequencyGHz", (float)admin_frequency_ghz.Value },
                { "socketType", admin_socket_type.Text }
            };

            var gpuData = new Dictionary<string, object>
            {
                { "memoryGB", (int)admin_memory_gb.Value },
                { "chipset", admin_chipset.Text }
            };

            // Base: Always include electronics
            MergeDict(finalData, electronicsData);

            // Conditional logic based on UI selections
            if (admin_phones_radioButton.Checked)
                MergeDict(finalData, phoneData);

            if (admin_fold_radioButton.Checked)
                MergeDict(finalData, foldData);

            if (admin_laptop_radioButton.Checked)
                MergeDict(finalData, laptopData);

            if (admin_gaming_laptop_radioButton.Checked)
            {
                MergeDict(finalData, laptopData); // Inherits from Laptop
                MergeDict(finalData, gamingLaptopData);
            }

            if (admin_two_in_one_radioButton.Checked)
            {
                MergeDict(finalData, laptopData); // Inherits from Laptop
                MergeDict(finalData, twoInOneData);
            }

            if (admin_cpu_radioButton.Checked)
                MergeDict(finalData, cpuData);

            if (admin_gpu_radioButton.Checked)
                MergeDict(finalData, gpuData);

            return finalData;
        }

        private void MergeDict(Dictionary<string, object> target, Dictionary<string, object> source)
        {
            foreach (var kvp in source)
                target[kvp.Key] = kvp.Value; // Overwrites if key already exists
        }

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

        public AdminMain(Form loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
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
            _loginForm.Close();
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
                
                admin_laptop_radio_groupbox.Show();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                admin_gpu_groupbox.Hide();
                admin_laptop_groupbox.Show();
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
                
                admin_gpu_groupbox.Hide();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_laptop_radio_groupbox.Hide();
                admin_cpu_groupbox.Show();
            }
        }

        private void admin_gpu_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (admin_gpu_radioButton.Checked)
            {
                
                admin_cpu_groupbox.Hide();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_laptop_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_two_in_one_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_laptop_radio_groupbox.Hide();
                admin_gpu_groupbox.Show();
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
                
                admin_two_in_one_laptop_groupbox.Show();
                admin_laptop_radio_groupbox.Show();
                admin_phone_groupbox.Hide();
                admin_fold_groupbox.Hide();
                admin_gaming_laptop_groupbox.Hide();
                admin_phones_radio_groupbox.Hide();
                admin_cpu_groupbox.Hide();
                admin_gpu_groupbox.Hide();
                admin_laptop_groupbox.Show();
            }
        }
        
        private void admin_add_Click(object sender, EventArgs e)
        {
            
            Dictionary<string, object> data = BuildFinalDictionary();

            object myDeviceInstance;

            if (admin_phones_radioButton.Checked)
                myDeviceInstance = new Phone();
            else if (admin_fold_radioButton.Checked)
                myDeviceInstance = new Fold();
            else if (admin_gaming_laptop_radioButton.Checked)
                myDeviceInstance = new GamingLaptop();
            else if (admin_two_in_one_radioButton.Checked)
                myDeviceInstance = new TwoInOne();
            else if (admin_laptop_radioButton.Checked)
                myDeviceInstance = new Laptop();
            else if (admin_cpu_radioButton.Checked)
                myDeviceInstance = new Cpu();
            else if (admin_gpu_radioButton.Checked)
                myDeviceInstance = new Gpu();
            else
                throw new InvalidOperationException("No device type selected.");

            // Set properties using dictionary
            SetPropertiesFromDictionary(myDeviceInstance, data);

            // Save to database
            ////Polymorphic save based on type
            ((Electronics)myDeviceInstance).SaveToDb(myConnectionString);


        }
        private void admin_search_Click(object sender, EventArgs e)
        {
            string searchValue = admin_search_textBox.Text;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please fill in search value.");
                return;
            }

            object myDeviceInstance;

            if (admin_phones_radioButton.Checked)
                myDeviceInstance = new Phone();
            else if (admin_fold_radioButton.Checked)
                myDeviceInstance = new Fold();
            else if (admin_gaming_laptop_radioButton.Checked)
                myDeviceInstance = new GamingLaptop();
            else if (admin_two_in_one_radioButton.Checked)
                myDeviceInstance = new TwoInOne();
            else if (admin_laptop_radioButton.Checked)
                myDeviceInstance = new Laptop();
            else if (admin_cpu_radioButton.Checked)
                myDeviceInstance = new Cpu();
            else if (admin_gpu_radioButton.Checked)
                myDeviceInstance = new Gpu();
            else
                throw new InvalidOperationException("No device type selected.");

            // Call dynamic GetData
            ((Electronics)myDeviceInstance).GetData(searchValue, myConnectionString);

            // Now update the UI from myDeviceInstance
            FillUIWithDeviceData(myDeviceInstance); // <- Make this a method to update all fields accordingly
        }
        private void FillUIWithDeviceData(object device)
        {
            if (device is Electronics e)
            {
                admin_name.Text = e.name;
                admin_brand.Text = e.brand;
                admin_model.Text = e.model;
                admin_color.Text = e.color;
                admin_price.Value = (decimal)e.price;
                admin_description.Text = e.description;
                admin_quantity.Value = e.quantity;
                admin_qrcode.Text = e.QRCode;

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
                admin_frame_rate.Value = gl.frameRate;
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
                admin_memory_gb.Value = g.memoryGB;
                admin_chipset.Text = g.chipset;
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.Show();
        }

        private void admin_upload_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an Image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Display image in PictureBox
                admin_pictureBox.Image = new Bitmap(ofd.FileName);
                admin_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // Convert image to byte array for saving to DB
                uploadedImageBytes = File.ReadAllBytes(ofd.FileName);
            }
        }
    }
}
