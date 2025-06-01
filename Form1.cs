using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static Market.Fold;

namespace Market
{
    public partial class Form1 : Form
    {
        protected Form _loginForm;
        UsersData user;
        string type = null;
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
        public Form1(Form login, UsersData user)
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
            this.user = user;
            money.Text = user.money.money.ToString();
            username.Text = user.username;
            if (user.money.discount > 0)
            {
                discount.Text = user.money.discount.ToString();
            }
            else
            {
                discount_label.Hide();
                discount.Hide();
            }
        }
        public Form1(Form login, string in_name, string type, UsersData user)
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
            this.type = type;
            CheckRadioButtonByType(type);
            this.user = user;
            money.Text = user.money.money.ToString();
            username.Text = user.username;
            if (user.money.discount > 0)
            {
                discount.Text = user.money.discount.ToString();
            }
            else
            {
                discount_label.Hide();
                discount.Hide();
            }

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
                        admin_pictureBox.Image = System.Drawing.Image.FromStream(ms);
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

        private void buy_Click(object sender, EventArgs e)
        {
            int soldCounter = 0; // Initialize to avoid unassigned variable issues

            // Decrease quantity and update user's money
            if (quantity.Value > quantity.Minimum)
            {
                quantity.Value -= 1;
            }
            else
            {
                MessageBox.Show("Quantity cannot be less than the minimum value.");
                return;
            }

            user.UpdateMoney((int)price.Value);

            // Step 1: Read current soldCounter value
            string selectQuery = $"SELECT soldCounter FROM {type} WHERE name = @name";
            using (SqlConnection conn = new SqlConnection(myConnectionString))
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@name", name.Text);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        soldCounter = Convert.ToInt32(reader["soldCounter"]) + 1;
                    }
                    else
                    {
                        MessageBox.Show($"Item with name '{name.Text}' not found in table '{type}'.");
                        return; // Exit early if item not found
                    }
                }
            }

            // Step 2: Update soldCounter value
            string updateQuery = $"UPDATE {type} SET soldCounter = @soldCounter WHERE name = @name";
            using (SqlConnection conn = new SqlConnection(myConnectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@soldCounter", soldCounter);
                cmd.Parameters.AddWithValue("@name", name.Text);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Update failed: No matching record found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}");
                    return;
                }
            }

            // Final updates
            Update(); // Save additional changes if any
            money.Text = user.money.money.ToString();
            username.Text = user.username;
        }

        public void Update()
        {

            Dictionary<string, object> data = BuildFinalDictionary();

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

            // Set properties using dictionary
            SetPropertiesFromDictionary(myDeviceInstance, data);

            // Save to database
            ((Electronics)myDeviceInstance).SaveToDbWithoutImage(myConnectionString);
        }
        /// Check if sold counter add 1
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
                { "name", name.Text },
                { "brand", brand.Text },
                { "model", model.Text },
                { "color", color.Text },
                { "price", (float)price.Value },
                { "description", description.Text },
                { "quantity", (int)quantity.Value },
                { "QRCode", qrcode.Text }
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
                { "memoryGB", (int)memory_gb.Value },
                { "chipset", chipset.Text }
            };

            // Base: Always include electronics
            MergeDict(finalData, electronicsData);

            // Conditional logic based on UI selections
            if (phones_radioButton.Checked)
                MergeDict(finalData, phoneData);

            if (fold_radioButton.Checked)
                MergeDict(finalData, foldData);

            if (laptop_radioButton.Checked)
                MergeDict(finalData, laptopData);

            if (gaming_laptop_radioButton.Checked)
            {
                MergeDict(finalData, laptopData); // Inherits from Laptop
                MergeDict(finalData, gamingLaptopData);
            }

            if (two_in_one_radioButton.Checked)
            {
                MergeDict(finalData, laptopData); // Inherits from Laptop
                MergeDict(finalData, twoInOneData);
            }

            if (cpu_radioButton.Checked)
                MergeDict(finalData, cpuData);

            if (gpu_radioButton.Checked)
                MergeDict(finalData, gpuData);

            return finalData;
        }
        private void MergeDict(Dictionary<string, object> target, Dictionary<string, object> source)
        {
            foreach (var kvp in source)
                target[kvp.Key] = kvp.Value; // Overwrites if key already exists
        }
        private void CheckRadioButtonByType(string type)
        {
            switch (type)
            {
                case "Phones":
                    phones_radioButton.Checked = true;
                    break;
                case "Folds":
                    phones_radioButton.Checked = true;  // Parent category
                    fold_radioButton.Checked = true;
                    break;
                case "Laptops":
                    laptop_radioButton.Checked = true;
                    break;
                case "GammingLaptops":
                    laptop_radioButton.Checked = true;  // Parent category
                    gaming_laptop_radioButton.Checked = true;
                    break;
                case "TwoInOnes":
                    laptop_radioButton.Checked = true;  // Parent category
                    two_in_one_radioButton.Checked = true;
                    break;
                case "Cpus":
                    cpu_radioButton.Checked = true;
                    break;
                case "Gpus":
                    gpu_radioButton.Checked = true;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown device type: {type}");
            }
        }

    }

}
