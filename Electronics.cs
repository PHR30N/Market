using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Required for async operations

namespace Market
{
    //string connectionString = "Data Source=localhost;Initial Catalog=MarketDB;Integrated Security=True;TrustServerCertificate=True";
    public abstract class Electronics
    {
        public string name { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public float price { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public string imagePath { get; set; }
        public string QRCode { get; set; } // Already string, good.

        // Constructor for base properties
        protected Electronics(string name, string brand, string model, string color, float price, string description, int quantity, string imagePath, string qrCode)
        {
            this.name = name;
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
            this.imagePath = imagePath;
            this.QRCode = qrCode;
        }
        // Parameterless constructor for cases where you might create an empty object then load data
        protected Electronics(string name, string brand, string model, string color, float price, int id, string description, int quantity, string imagePath, string qrCode)
        {
            this.name = name;
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.id = id;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
            this.imagePath = imagePath;
            this.QRCode = qrCode;
        }
        // Abstract method to save to DB, to be implemented by derived classes
        public abstract Task SaveToDbAsync(string connectionString);

        // Abstract method to get data, to be implemented by derived classes
        public abstract Task GetDataAsync(string in_name, string connectionString);

        // ToString remains abstract as its representation is entity-specific
        public abstract override string ToString();
    }
    public class Phone : Electronics
    {
        public string operatingSystem { get; set; }
        public float screenSize { get; set; }
        public int storageCapacity { get; set; }
        public int ramSize { get; set; }
        public int cameraQuality { get; set; }
        public string cpuType { get; set; }
        public int batteryCapacity { get; set; }
        public bool tablet { get; set; }
        // Constructor
        public Phone(
            string name, string brand, string model, string color, float price,
            string description, int quantity, string imagePath, string qrCode,
            string operatingSystem, float screenSize, int storageCapacity, int ramSize,
            int cameraQuality, string cpuType, int batteryCapacity, bool tablet)
            : base(name, brand, model, color, price, description, quantity, imagePath, qrCode)
        {
            this.operatingSystem = operatingSystem;
            this.screenSize = screenSize;
            this.storageCapacity = storageCapacity;
            this.ramSize = ramSize;
            this.cameraQuality = cameraQuality;
            this.cpuType = cpuType;
            this.batteryCapacity = batteryCapacity;
            this.tablet = tablet;
        }
        public Phone(
            string name, string brand, string model, string color, float price, int id,
            string description, int quantity, string imagePath, string qrCode,
            string operatingSystem, float screenSize, int storageCapacity, int ramSize,
            int cameraQuality, string cpuType, int batteryCapacity, bool tablet)
            : base(name, brand, model, color, price, id, description, quantity, imagePath, qrCode)
        {
            this.operatingSystem = operatingSystem;
            this.screenSize = screenSize;
            this.storageCapacity = storageCapacity;
            this.ramSize = ramSize;
            this.cameraQuality = cameraQuality;
            this.cpuType = cpuType;
            this.batteryCapacity = batteryCapacity;
            this.tablet = tablet;
        }

        // Parameterless constructor for cases where you might create an empty object then load data
        public Phone() : base(null, null, null, null, 0, null, 0, null, null) { }


        public override async Task SaveToDbAsync(string connectionString)
        {
            string insertQuery = "INSERT INTO Phones (name, brand, model, color, price, description, quantity, imagePath, QRCode, operatingSystem, screenSize, storageCapacity, ramSize, cameraQuality, cpuType, batteryCapacity, tablet) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @description, @quantity, @imagePath, @QRCode, @operatingSystem, @screenSize, @storageCapacity, @ramSize, @cameraQuality, @cpuType, @batteryCapacity, @tablet)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);
                    cmd.Parameters.AddWithValue("@QRCode", QRCode);
                    cmd.Parameters.AddWithValue("@operatingSystem", (object)operatingSystem ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@screenSize", screenSize);
                    cmd.Parameters.AddWithValue("@storageCapacity", storageCapacity);
                    cmd.Parameters.AddWithValue("@ramSize", ramSize);
                    cmd.Parameters.AddWithValue("@cameraQuality", cameraQuality);
                    cmd.Parameters.AddWithValue("@cpuType", (object)cpuType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@batteryCapacity", batteryCapacity);
                    cmd.Parameters.AddWithValue("@tablet", tablet);

                    try
                    {
                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database Error: {ex.Message}");
                    }
                }
            }
        }

        public override async Task GetDataAsync(string in_name, string connectionString)
        {
            string selectQuery = "SELECT * FROM Phones WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@name", in_name);
                await conn.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    
                    if (await reader.ReadAsync())
                    {
                        this.name = reader["name"].ToString();
                        this.brand = reader["brand"].ToString();
                        this.model = reader["model"].ToString();
                        this.color = reader["color"].ToString();
                        this.price = Convert.ToSingle(reader["price"]);
                        this.id = Convert.ToInt32(reader["id"]);
                        this.description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null;
                        this.quantity = Convert.ToInt32(reader["quantity"]);
                        this.imagePath = reader["imagePath"].ToString();
                        this.QRCode = reader["QRCode"].ToString();
                        this.operatingSystem = reader["operatingSystem"] != DBNull.Value ? reader["operatingSystem"].ToString() : null;
                        this.screenSize = Convert.ToSingle(reader["screenSize"]);
                        this.storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                        this.ramSize = Convert.ToInt32(reader["ramSize"]);
                        this.cameraQuality = Convert.ToInt32(reader["cameraQuality"]);
                        this.cpuType = reader["cpuType"] != DBNull.Value ? reader["cpuType"].ToString() : null;
                        this.batteryCapacity = Convert.ToInt32(reader["batteryCapacity"]);
                        this.tablet = Convert.ToBoolean(reader["tablet"]);
                        //MessageBox.Show("Entered Method" + this.batteryCapacity);
                    }
                }
            }
        }
        /*
        private void UpdateAdminFields(Phone myPhone)
        {
            admin_brand.Text = myPhone.brand;
            admin_model.Text = myPhone.model;
            admin_color.Text = myPhone.color;
            admin_price.Value = (decimal)myPhone.price;
            admin_description.Text = myPhone.description;
            admin_quantity.Value = myPhone.quantity;
            admin_image_path.Text = myPhone.imagePath;
            admin_qrcode.Text = myPhone.QRCode;
            admin_phone_os.Text = myPhone.operatingSystem;
            admin_phone_screen_size.Value = (decimal)myPhone.screenSize;
            admin_phone_storage.Value = myPhone.storageCapacity;
            admin_ram_size.Value = myPhone.ramSize;
            admin_phone_camera.Value = myPhone.cameraQuality;
            admin_phone_cpu.Text = myPhone.cpuType;
            admin_phone_battery.Value = myPhone.batteryCapacity;
            admin_tablet.Checked = myPhone.tablet;
        }*/
        public override string ToString()
        {
            return $"Phone: {name}, Brand: {brand}, Model: {model}, Color: {color}, Price: {price:C}, ID: {id}, Quantity: {quantity}, QRCode: {QRCode}, OS: {operatingSystem}, Screen: {screenSize}\", Storage: {storageCapacity}GB, RAM: {ramSize}GB, Camera: {cameraQuality}MP, CPU: {cpuType}, Battery: {batteryCapacity}mAh, Tablet: {tablet}\nDescription: {description}\nImage: {imagePath}";
        }

        public static string Compare(Phone a, Phone b)
        {
            if (a == null || b == null) return "Cannot compare null objects.";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing Phone: {a.name} vs {b.name}");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            // ... (include all properties as before, for brevity not repeating all here)
            sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
            sb.AppendLine($"OS: {a.operatingSystem} vs {b.operatingSystem}");
            sb.AppendLine($"Screen Size: {a.screenSize}\" vs {b.screenSize}\"");
            sb.AppendLine($"Storage: {a.storageCapacity}GB vs {b.storageCapacity}GB");
            sb.AppendLine($"RAM: {a.ramSize}GB vs {b.ramSize}GB");
            sb.AppendLine($"Camera: {a.cameraQuality}MP vs {b.cameraQuality}MP");
            sb.AppendLine($"CPU: {a.cpuType} vs {b.cpuType}");
            sb.AppendLine($"Battery: {a.batteryCapacity}mAh vs {b.batteryCapacity}mAh");
            sb.AppendLine($"Tablet: {a.tablet} vs {b.tablet}");
            return sb.ToString();
        }
    }
    public class Fold : Phone
    {
        public string foldType { get; set; }
        public string hingeMaterial { get; set; }
        public string displayType { get; set; }
        public string durabilityRating { get; set; }
        public float sizeOfOpenedScreen { get; set; }

        public Fold(
            // Phone properties
            string name, string brand, string model, string color, float price, int id,
            string description, int quantity, string imagePath, string qrCode,
            string operatingSystem, float screenSize, int storageCapacity, int ramSize,
            int cameraQuality, string cpuType, int batteryCapacity, bool tablet,
            // Fold specific properties
            string foldType, string hingeMaterial, string displayType, string durabilityRating, float sizeOfOpenedScreen)
            : base(name, brand, model, color, price, id, description, quantity, imagePath, qrCode,
                  operatingSystem, screenSize, storageCapacity, ramSize, cameraQuality, cpuType, batteryCapacity, tablet)
        {
            this.foldType = foldType;
            this.hingeMaterial = hingeMaterial;
            this.displayType = displayType;
            this.durabilityRating = durabilityRating;
            this.sizeOfOpenedScreen = sizeOfOpenedScreen;
        }

        public Fold() : base() { } // For empty object creation

        public override async Task SaveToDbAsync(string connectionString)
        {
            // Note: This assumes you want to save all Phone properties + Fold properties
            string insertQuery = "INSERT INTO Folds (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                 "operatingSystem, screenSize, storageCapacity, ramSize, cameraQuality, cpuType, batteryCapacity, tablet, " +
                                 "foldType, hingeMaterial, displayType, durabilityRating, sizeOfOpenedScreen) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                 "@operatingSystem, @screenSize, @storageCapacity, @ramSize, @cameraQuality, @cpuType, @batteryCapacity, @tablet, " +
                                 "@foldType, @hingeMaterial, @displayType, @durabilityRating, @sizeOfOpenedScreen)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    // Phone Properties
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);
                    cmd.Parameters.AddWithValue("@QRCode", QRCode);
                    cmd.Parameters.AddWithValue("@operatingSystem", (object)operatingSystem ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@screenSize", screenSize);
                    cmd.Parameters.AddWithValue("@storageCapacity", storageCapacity);
                    cmd.Parameters.AddWithValue("@ramSize", ramSize);
                    cmd.Parameters.AddWithValue("@cameraQuality", cameraQuality);
                    cmd.Parameters.AddWithValue("@cpuType", (object)cpuType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@batteryCapacity", batteryCapacity);
                    cmd.Parameters.AddWithValue("@tablet", tablet);
                    // Fold Specific Properties
                    cmd.Parameters.AddWithValue("@foldType", foldType);
                    cmd.Parameters.AddWithValue("@hingeMaterial", hingeMaterial);
                    cmd.Parameters.AddWithValue("@displayType", displayType);
                    cmd.Parameters.AddWithValue("@durabilityRating", durabilityRating);
                    cmd.Parameters.AddWithValue("@sizeOfOpenedScreen", sizeOfOpenedScreen);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public override async Task GetDataAsync(string in_name, string connectionString)
        {
            string selectQuery = "SELECT * FROM Folds WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", in_name);
                    await conn.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            // Base Phone properties
                            this.name = reader["name"].ToString();
                            this.brand = reader["brand"].ToString();
                            this.model = reader["model"].ToString();
                            // ... (all phone properties as in Phone.GetDataAsync)
                            this.price = Convert.ToSingle(reader["price"]);
                            this.id = Convert.ToInt32(reader["id"]);
                            this.description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null;
                            this.quantity = Convert.ToInt32(reader["quantity"]);
                            this.imagePath = reader["imagePath"].ToString();
                            this.QRCode = reader["QRCode"].ToString();
                            this.operatingSystem = reader["operatingSystem"] != DBNull.Value ? reader["operatingSystem"].ToString() : null;
                            this.screenSize = Convert.ToSingle(reader["screenSize"]);
                            this.storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                            this.ramSize = Convert.ToInt32(reader["ramSize"]);
                            this.cameraQuality = Convert.ToInt32(reader["cameraQuality"]);
                            this.cpuType = reader["cpuType"] != DBNull.Value ? reader["cpuType"].ToString() : null;
                            this.batteryCapacity = Convert.ToInt32(reader["batteryCapacity"]);
                            this.tablet = Convert.ToBoolean(reader["tablet"]);

                            // Fold specific properties
                            this.foldType = reader["foldType"].ToString();
                            this.hingeMaterial = reader["hingeMaterial"].ToString();
                            this.displayType = reader["displayType"].ToString();
                            this.durabilityRating = reader["durabilityRating"].ToString();
                            this.sizeOfOpenedScreen = Convert.ToSingle(reader["sizeOfOpenedScreen"]);
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Fold Type: {foldType}, Hinge: {hingeMaterial}, Display: {displayType}, Durability: {durabilityRating}, Opened Screen: {sizeOfOpenedScreen}\"";
        }

        public static string Compare(Fold a, Fold b) // Note: static methods cannot be override
        {
            if (a == null || b == null) return "Cannot compare null objects.";
            StringBuilder sb = new StringBuilder();
            sb.Append(Phone.Compare(a, b)); // Leverage base class comparison
            sb.AppendLine($"Fold Type: {a.foldType} vs {b.foldType}");
            sb.AppendLine($"Hinge Material: {a.hingeMaterial} vs {b.hingeMaterial}");
            sb.AppendLine($"Display Type: {a.displayType} vs {b.displayType}");
            sb.AppendLine($"Durability: {a.durabilityRating} vs {b.durabilityRating}");
            sb.AppendLine($"Opened Screen Size: {a.sizeOfOpenedScreen}\" vs {b.sizeOfOpenedScreen}\"");
            return sb.ToString();
        }
        public class Laptop : Electronics
        {
            public string operatingSystem { get; set; }
            public int storageCapacity { get; set; }
            public int ramSize { get; set; }
            public string graphicsCard { get; set; }
            public string cpuType { get; set; }
            public float screenSize { get; set; }
            public string batteryLife { get; set; }

            public Laptop(
                string name, string brand, string model, string color, float price, int id,
                string description, int quantity, string imagePath, string qrCode,
                string operatingSystem, int storageCapacity, int ramSize, string graphicsCard,
                string cpuType, float screenSize, string batteryLife)
                : base(name, brand, model, color, price, id, description, quantity, imagePath, qrCode)
            {
                this.operatingSystem = operatingSystem;
                this.storageCapacity = storageCapacity;
                this.ramSize = ramSize;
                this.graphicsCard = graphicsCard;
                this.cpuType = cpuType;
                this.screenSize = screenSize;
                this.batteryLife = batteryLife;
            }

            public Laptop() : base(null, null, null, null, 0, 0, null, 0, null, null) { }


            public override async Task SaveToDbAsync(string connectionString)
            {
                string insertQuery = "INSERT INTO Laptops (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                     "operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife) " +
                                     "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                     "@operatingSystem, @storageCapacity, @ramSize, @graphicsCard, @cpuType, @screenSize, @batteryLife)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@model", model);
                        // ... (all Electronics + Laptop specific params, ensuring DBNull for nullables)
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@imagePath", imagePath);
                        cmd.Parameters.AddWithValue("@QRCode", QRCode);
                        cmd.Parameters.AddWithValue("@operatingSystem", operatingSystem);
                        cmd.Parameters.AddWithValue("@storageCapacity", storageCapacity);
                        cmd.Parameters.AddWithValue("@ramSize", ramSize);
                        cmd.Parameters.AddWithValue("@graphicsCard", graphicsCard);
                        cmd.Parameters.AddWithValue("@cpuType", cpuType);
                        cmd.Parameters.AddWithValue("@screenSize", screenSize);
                        cmd.Parameters.AddWithValue("@batteryLife", batteryLife);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }

            public override async Task GetDataAsync(string in_name, string connectionString)
            {
                string selectQuery = "SELECT * FROM Laptops WHERE name = @name";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", in_name);
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Electronics properties
                                this.name = reader["name"].ToString();
                                this.brand = reader["brand"].ToString();
                                this.model = reader["model"].ToString();
                                this.color = reader["color"].ToString();
                                this.price = Convert.ToSingle(reader["price"]);
                                this.id = Convert.ToInt32(reader["id"]);
                                this.description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null;
                                this.quantity = Convert.ToInt32(reader["quantity"]);
                                this.imagePath = reader["imagePath"].ToString();
                                this.QRCode = reader["QRCode"].ToString();
                                // Laptop specific
                                this.operatingSystem = reader["operatingSystem"].ToString();
                                this.storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                                this.ramSize = Convert.ToInt32(reader["ramSize"]);
                                this.graphicsCard = reader["graphicsCard"].ToString();
                                this.cpuType = reader["cpuType"].ToString();
                                this.screenSize = Convert.ToSingle(reader["screenSize"]);
                                this.batteryLife = reader["batteryLife"].ToString();
                            }
                        }
                    }
                }
            }

            public override string ToString()
            {
                return $"Laptop: {name}, Brand: {brand}, Model: {model}, Price: {price:C}, ID:{id}, QRCode: {QRCode}, OS: {operatingSystem}, Storage: {storageCapacity}GB, RAM: {ramSize}GB, GPU: {graphicsCard}, CPU: {cpuType}, Screen: {screenSize}\", Battery: {batteryLife}\nDesc: {description}";
            }

            public static string Compare(Laptop a, Laptop b)
            {
                if (a == null || b == null) return "Cannot compare null objects.";
                StringBuilder sb = new StringBuilder();
                // Basic Electronics Compare (could be a helper in Electronics if needed often)
                sb.AppendLine($"Comparing Laptop: {a.name} vs {b.name}");
                sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
                sb.AppendLine($"Model: {a.model} vs {b.model}");
                sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
                // Laptop specific
                sb.AppendLine($"OS: {a.operatingSystem} vs {b.operatingSystem}");
                sb.AppendLine($"Storage: {a.storageCapacity}GB vs {b.storageCapacity}GB");
                sb.AppendLine($"RAM: {a.ramSize}GB vs {b.ramSize}GB");
                sb.AppendLine($"Graphics: {a.graphicsCard} vs {b.graphicsCard}");
                sb.AppendLine($"CPU: {a.cpuType} vs {b.cpuType}");
                sb.AppendLine($"Screen Size: {a.screenSize}\" vs {b.screenSize}\"");
                sb.AppendLine($"Battery Life: {a.batteryLife} vs {b.batteryLife}");
                return sb.ToString();
            }
        }
        public class GamingLaptop : Laptop
        {
            public string coolingSystem { get; set; }
            public string keyboardType { get; set; }
            public int frameRate { get; set; }

            public GamingLaptop(
                // Laptop properties
                string name, string brand, string model, string color, float price, int id,
                string description, int quantity, string imagePath, string qrCode,
                string operatingSystem, int storageCapacity, int ramSize, string graphicsCard,
                string cpuType, float screenSize, string batteryLife,
                // GamingLaptop specific
                string coolingSystem, string keyboardType, int frameRate)
                : base(name, brand, model, color, price, id, description, quantity, imagePath, qrCode,
                      operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife)
            {
                this.coolingSystem = coolingSystem;
                this.keyboardType = keyboardType;
                this.frameRate = frameRate;
            }

            public GamingLaptop() : base() { }


            public override async Task SaveToDbAsync(string connectionString)
            {
                // Using GammingLaptops table name as per DDL
                string insertQuery = "INSERT INTO GammingLaptops (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                     "operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife, " +
                                     "coolingSystem, keyboardType, frameRate) " +
                                     "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                     "@operatingSystem, @storageCapacity, @ramSize, @graphicsCard, @cpuType, @screenSize, @batteryLife, " +
                                     "@coolingSystem, @keyboardType, @frameRate)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Laptop params
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@brand", brand);
                        // ... (all Laptop params)
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@imagePath", imagePath);
                        cmd.Parameters.AddWithValue("@QRCode", QRCode);
                        cmd.Parameters.AddWithValue("@operatingSystem", operatingSystem);
                        cmd.Parameters.AddWithValue("@storageCapacity", storageCapacity);
                        cmd.Parameters.AddWithValue("@ramSize", ramSize);
                        cmd.Parameters.AddWithValue("@graphicsCard", graphicsCard);
                        cmd.Parameters.AddWithValue("@cpuType", cpuType);
                        cmd.Parameters.AddWithValue("@screenSize", screenSize);
                        cmd.Parameters.AddWithValue("@batteryLife", batteryLife);
                        // GamingLaptop params
                        cmd.Parameters.AddWithValue("@coolingSystem", coolingSystem);
                        cmd.Parameters.AddWithValue("@keyboardType", keyboardType);
                        cmd.Parameters.AddWithValue("@frameRate", frameRate);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }

            public override async Task GetDataAsync(string in_name, string connectionString)
            {
                // Using GammingLaptops table name as per DDL
                string selectQuery = "SELECT * FROM GammingLaptops WHERE name = @name";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", in_name);
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Laptop properties
                                this.name = reader["name"].ToString();
                                this.brand = reader["brand"].ToString();
                                // ... (all Laptop properties)
                                this.model = reader["model"].ToString();
                                this.color = reader["color"].ToString();
                                this.price = Convert.ToSingle(reader["price"]);
                                this.id = Convert.ToInt32(reader["id"]);
                                this.description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null;
                                this.quantity = Convert.ToInt32(reader["quantity"]);
                                this.imagePath = reader["imagePath"].ToString();
                                this.QRCode = reader["QRCode"].ToString();
                                this.operatingSystem = reader["operatingSystem"].ToString();
                                this.storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                                this.ramSize = Convert.ToInt32(reader["ramSize"]);
                                this.graphicsCard = reader["graphicsCard"].ToString();
                                this.cpuType = reader["cpuType"].ToString();
                                this.screenSize = Convert.ToSingle(reader["screenSize"]);
                                this.batteryLife = reader["batteryLife"].ToString();
                                // GamingLaptop specific
                                this.coolingSystem = reader["coolingSystem"].ToString();
                                this.keyboardType = reader["keyboardType"].ToString();
                                this.frameRate = Convert.ToInt32(reader["frameRate"]);
                            }
                        }
                    }
                }
            }


            public override string ToString()
            {
                return $"{base.ToString()}, Cooling: {coolingSystem}, Keyboard: {keyboardType}, Max FPS: {frameRate}";
            }

            public static string Compare(GamingLaptop a, GamingLaptop b)
            {
                if (a == null || b == null) return "Cannot compare null objects.";
                StringBuilder sb = new StringBuilder();
                sb.Append(Laptop.Compare(a, b));
                sb.AppendLine($"Cooling: {a.coolingSystem} vs {b.coolingSystem}");
                sb.AppendLine($"Keyboard: {a.keyboardType} vs {b.keyboardType}");
                sb.AppendLine($"FPS: {a.frameRate} vs {b.frameRate}");
                return sb.ToString();
            }
        }
        public class TwoInOne : Laptop
        {
            public bool detachableKeyboard { get; set; }
            public string hingeType { get; set; }

            public TwoInOne(
                // Laptop properties
                string name, string brand, string model, string color, float price, int id,
                string description, int quantity, string imagePath, string qrCode,
                string operatingSystem, int storageCapacity, int ramSize, string graphicsCard,
                string cpuType, float screenSize, string batteryLife,
                // TwoInOne specific
                bool detachableKeyboard, string hingeType)
                : base(name, brand, model, color, price, id, description, quantity, imagePath, qrCode,
                      operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife)
            {
                this.detachableKeyboard = detachableKeyboard;
                this.hingeType = hingeType;
            }

            public TwoInOne() : base() { }

            public override async Task SaveToDbAsync(string connectionString)
            {
                string insertQuery = "INSERT INTO TwoInOnes (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                     "operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife, " +
                                     "detachableKeyboard, hingeType) " +
                                     "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                     "@operatingSystem, @storageCapacity, @ramSize, @graphicsCard, @cpuType, @screenSize, @batteryLife, " +
                                     "@detachableKeyboard, @hingeType)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Laptop params
                        cmd.Parameters.AddWithValue("@name", name);
                        // ... (all Laptop params)
                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@imagePath", imagePath);
                        cmd.Parameters.AddWithValue("@QRCode", QRCode);
                        cmd.Parameters.AddWithValue("@operatingSystem", operatingSystem);
                        cmd.Parameters.AddWithValue("@storageCapacity", storageCapacity);
                        cmd.Parameters.AddWithValue("@ramSize", ramSize);
                        cmd.Parameters.AddWithValue("@graphicsCard", graphicsCard);
                        cmd.Parameters.AddWithValue("@cpuType", cpuType);
                        cmd.Parameters.AddWithValue("@screenSize", screenSize);
                        cmd.Parameters.AddWithValue("@batteryLife", batteryLife);
                        // TwoInOne params
                        cmd.Parameters.AddWithValue("@detachableKeyboard", detachableKeyboard);
                        cmd.Parameters.AddWithValue("@hingeType", hingeType);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }

            public override async Task GetDataAsync(string in_name, string connectionString)
            {
                string selectQuery = "SELECT * FROM TwoInOnes WHERE name = @name";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", in_name);
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Laptop properties
                                this.name = reader["name"].ToString();
                                // ... (all Laptop properties)
                                this.brand = reader["brand"].ToString();
                                this.model = reader["model"].ToString();
                                this.color = reader["color"].ToString();
                                this.price = Convert.ToSingle(reader["price"]);
                                this.id = Convert.ToInt32(reader["id"]);
                                this.description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null;
                                this.quantity = Convert.ToInt32(reader["quantity"]);
                                this.imagePath = reader["imagePath"].ToString();
                                this.QRCode = reader["QRCode"].ToString();
                                this.operatingSystem = reader["operatingSystem"].ToString();
                                this.storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                                this.ramSize = Convert.ToInt32(reader["ramSize"]);
                                this.graphicsCard = reader["graphicsCard"].ToString();
                                this.cpuType = reader["cpuType"].ToString();
                                this.screenSize = Convert.ToSingle(reader["screenSize"]);
                                this.batteryLife = reader["batteryLife"].ToString();
                                // TwoInOne specific
                                this.detachableKeyboard = Convert.ToBoolean(reader["detachableKeyboard"]);
                                this.hingeType = reader["hingeType"].ToString();
                            }
                        }
                    }
                }
            }

            public override string ToString()
            {
                return $"{base.ToString()}, Detachable Keyboard: {detachableKeyboard}, Hinge: {hingeType}";
            }

            public static string Compare(TwoInOne a, TwoInOne b)
            {
                if (a == null || b == null) return "Cannot compare null objects.";
                StringBuilder sb = new StringBuilder();
                sb.Append(Laptop.Compare(a, b));
                sb.AppendLine($"Detachable Keyboard: {a.detachableKeyboard} vs {b.detachableKeyboard}");
                sb.AppendLine($"Hinge Type: {a.hingeType} vs {b.hingeType}");
                return sb.ToString();
            }
        }
        public class Cpu : Electronics
        {
            public int cores { get; set; }
            public float frequencyGHz { get; set; }
            public string socketType { get; set; }

            public Cpu(
                string name, string brand, string model, string color, float price, int id,
                string description, int quantity, string imagePath, string qrCode,
                int cores, float frequencyGHz, string socketType)
                : base(name, brand, model, color, price, id, description, quantity, imagePath, qrCode)
            {
                this.cores = cores;
                this.frequencyGHz = frequencyGHz;
                this.socketType = socketType;
            }

            public Cpu() : base(null, null, null, null, 0, 0, null, 0, null, null) { }

            public override async Task SaveToDbAsync(string connectionString)
            {
                string insertQuery = "INSERT INTO Cpus (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                     "cores, frequencyGHz, socketType) " +
                                     "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                     "@cores, @frequencyGHz, @socketType)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Electronics params
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@imagePath", imagePath);
                        cmd.Parameters.AddWithValue("@QRCode", QRCode);
                        // Cpu params
                        cmd.Parameters.AddWithValue("@cores", cores);
                        cmd.Parameters.AddWithValue("@frequencyGHz", frequencyGHz);
                        cmd.Parameters.AddWithValue("@socketType", socketType);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }

            public override async Task GetDataAsync(string in_name, string connectionString)
            {
                string selectQuery = "SELECT * FROM Cpus WHERE name = @name";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", in_name);
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Electronics properties
                                this.name = reader["name"].ToString();
                                this.brand = reader["brand"].ToString();
                                this.model = reader["model"].ToString();
                                this.color = reader["color"].ToString();
                                this.price = Convert.ToSingle(reader["price"]);
                                this.id = Convert.ToInt32(reader["id"]);
                                this.description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null;
                                this.quantity = Convert.ToInt32(reader["quantity"]);
                                this.imagePath = reader["imagePath"].ToString();
                                this.QRCode = reader["QRCode"].ToString();
                                // Cpu specific
                                this.cores = Convert.ToInt32(reader["cores"]);
                                this.frequencyGHz = Convert.ToSingle(reader["frequencyGHz"]);
                                this.socketType = reader["socketType"].ToString();
                            }
                        }
                    }
                }
            }

            public override string ToString()
            {
                return $"CPU: {name}, Brand: {brand}, Model: {model}, Price: {price:C}, ID:{id}, QRCode: {QRCode}, Cores: {cores}, Freq: {frequencyGHz}GHz, Socket: {socketType}\nDesc: {description}";
            }

            public static string Compare(Cpu a, Cpu b)
            {
                if (a == null || b == null) return "Cannot compare null objects.";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Comparing CPU: {a.name} vs {b.name}");
                sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
                sb.AppendLine($"Model: {a.model} vs {b.model}");
                sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
                sb.AppendLine($"Cores: {a.cores} vs {b.cores}");
                sb.AppendLine($"Frequency: {a.frequencyGHz}GHz vs {b.frequencyGHz}GHz");
                sb.AppendLine($"Socket: {a.socketType} vs {b.socketType}");
                return sb.ToString();
            }
        }
        public class Gpu : Electronics
        {
            public int memoryGB { get; set; }
            public string chipset { get; set; }

            public Gpu(
                string name, string brand, string model, string color, float price, int id,
                string description, int quantity, string imagePath, string qrCode,
                int memoryGB, string chipset)
                : base(name, brand, model, color, price, id, description, quantity, imagePath, qrCode)
            {
                this.memoryGB = memoryGB;
                this.chipset = chipset;
            }

            public Gpu() : base(null, null, null, null, 0, 0, null, 0, null, null) { }


            public override async Task SaveToDbAsync(string connectionString)
            {
                string insertQuery = "INSERT INTO Gpus (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                     "memoryGB, chipset) " +
                                     "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                     "@memoryGB, @chipset)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Electronics params
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@color", color);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@imagePath", imagePath);
                        cmd.Parameters.AddWithValue("@QRCode", QRCode);
                        // Gpu params
                        cmd.Parameters.AddWithValue("@memoryGB", memoryGB);
                        cmd.Parameters.AddWithValue("@chipset", chipset);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }

            public override async Task GetDataAsync(string in_name, string connectionString)
            {
                string selectQuery = "SELECT * FROM Gpus WHERE name = @name";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", in_name);
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Electronics properties
                                this.name = reader["name"].ToString();
                                this.brand = reader["brand"].ToString();
                                this.model = reader["model"].ToString();
                                this.color = reader["color"].ToString();
                                this.price = Convert.ToSingle(reader["price"]);
                                this.id = Convert.ToInt32(reader["id"]);
                                this.description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null;
                                this.quantity = Convert.ToInt32(reader["quantity"]);
                                this.imagePath = reader["imagePath"].ToString();
                                this.QRCode = reader["QRCode"].ToString();
                                // Gpu specific
                                this.memoryGB = Convert.ToInt32(reader["memoryGB"]);
                                this.chipset = reader["chipset"].ToString();
                            }
                        }
                    }
                }
            }

            public override string ToString()
            {
                return $"GPU: {name}, Brand: {brand}, Model: {model}, Price: {price:C}, ID:{id}, QRCode: {QRCode}, Memory: {memoryGB}GB, Chipset: {chipset}\nDesc: {description}";
            }

            public static string Compare(Gpu a, Gpu b)
            {
                if (a == null || b == null) return "Cannot compare null objects.";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Comparing GPU: {a.name} vs {b.name}");
                sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
                sb.AppendLine($"Model: {a.model} vs {b.model}");
                sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
                sb.AppendLine($"Memory: {a.memoryGB}GB vs {b.memoryGB}GB");
                sb.AppendLine($"Chipset: {a.chipset} vs {b.chipset}");
                return sb.ToString();
            }
        }
    }
}



// Example: Creating and Saving a Phone
// string myConnectionString = "your_actual_connection_string_here"; // Get from config

// Phone myPhone = new Phone(
// name: "Galaxy S24 Ultra",
// brand: "Samsung",
// model: "SM-S928B",
// color: "Titanium Gray",
// price: 1299.99f,
// id: 101,
// description: "The latest flagship with AI features.",
// quantity: 50,
// imagePath: "/images/s24ultra.png",
// qrCode: "S24ULTRA101QR",
// operatingSystem: "Android 14",
// screenSize: 6.8f,
// storageCapacity: 512,
// ramSize: 12,
// cameraQuality: 200,
// cpuType: "Snapdragon 8 Gen 3 for Galaxy",
// batteryCapacity: 5000,
// tablet: false
// );

// await myPhone.SaveToDbAsync(myConnectionString);
// Console.WriteLine("Phone saved!");

// Example: Getting data for an existing phone
// Phone existingPhone = new Phone(); // Create an empty instance
// await existingPhone.GetDataAsync("Galaxy S24 Ultra", myConnectionString);

// if (!string.IsNullOrEmpty(existingPhone.name))
// {
//    Console.WriteLine(existingPhone.ToString());
// }
// else
// {
//    Console.WriteLine("Phone not found.");
// }