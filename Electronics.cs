using System;
using System.Data.SqlClient;
using System.Text;

namespace Market
{
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
        public string QRCode { get; set; } // Changed from int to string

        public abstract void SetData(params object[] parameters);
        public abstract void GetData(string in_name);
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
        public bool tablet { get; set; } // Added tablet property

        // Total properties: 10 (Electronics) + 8 (Phone) = 18
        public override void SetData(params object[] parameters)
        {
            if (parameters.Length != 18) // Updated count
                throw new ArgumentException("Invalid number of parameters for Phone. Expected 18.");

            name = (string)parameters[0];
            brand = (string)parameters[1];
            model = (string)parameters[2];
            color = (string)parameters[3];
            price = Convert.ToSingle(parameters[4]);
            id = Convert.ToInt32(parameters[5]);
            description = (string)parameters[6];
            quantity = Convert.ToInt32(parameters[7]);
            imagePath = (string)parameters[8];
            QRCode = (string)parameters[9]; // Changed to string
            operatingSystem = (string)parameters[10];
            screenSize = Convert.ToSingle(parameters[11]);
            storageCapacity = Convert.ToInt32(parameters[12]);
            ramSize = Convert.ToInt32(parameters[13]);
            cameraQuality = Convert.ToInt32(parameters[14]);
            cpuType = (string)parameters[15];
            batteryCapacity = Convert.ToInt32(parameters[16]);
            tablet = Convert.ToBoolean(parameters[17]); // Added tablet

            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            // Added 'tablet' to query
            string insertQuery = "INSERT INTO Phones (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, operatingSystem, screenSize, storageCapacity, ramSize, cameraQuality, cpuType, batteryCapacity, tablet) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, @operatingSystem, @screenSize, @storageCapacity, @ramSize, @cameraQuality, @cpuType, @batteryCapacity, @tablet)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
                cmd.Parameters.AddWithValue("@QRCode", QRCode);
                cmd.Parameters.AddWithValue("@operatingSystem", operatingSystem);
                cmd.Parameters.AddWithValue("@screenSize", screenSize);
                cmd.Parameters.AddWithValue("@storageCapacity", storageCapacity);
                cmd.Parameters.AddWithValue("@ramSize", ramSize);
                cmd.Parameters.AddWithValue("@cameraQuality", cameraQuality);
                cmd.Parameters.AddWithValue("@cpuType", cpuType);
                cmd.Parameters.AddWithValue("@batteryCapacity", batteryCapacity);
                cmd.Parameters.AddWithValue("@tablet", tablet); // Added tablet parameter

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void GetData(string in_name)
        {
            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string selectQuery = "SELECT * FROM Phones WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@name", in_name);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["name"].ToString();
                        brand = reader["brand"].ToString();
                        model = reader["model"].ToString();
                        color = reader["color"].ToString();
                        price = Convert.ToSingle(reader["price"]);
                        id = Convert.ToInt32(reader["id"]);
                        description = reader["description"].ToString();
                        quantity = Convert.ToInt32(reader["quantity"]);
                        imagePath = reader["imagePath"].ToString();
                        QRCode = reader["QRCode"].ToString(); // Changed to string
                        operatingSystem = reader["operatingSystem"].ToString();
                        screenSize = Convert.ToSingle(reader["screenSize"]);
                        storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                        ramSize = Convert.ToInt32(reader["ramSize"]);
                        cameraQuality = Convert.ToInt32(reader["cameraQuality"]);
                        cpuType = reader["cpuType"].ToString();
                        batteryCapacity = Convert.ToInt32(reader["batteryCapacity"]);
                        tablet = Convert.ToBoolean(reader["tablet"]); // Added tablet
                    }
                }
                conn.Close();
            }
        }

        public override string ToString()
        {
            // Added tablet to string
            return $"Phone: {name}, Brand: {brand}, Model: {model}, Color: {color}, Price: {price:C}, ID: {id}, Description: {description}, Quantity: {quantity}, ImagePath: {imagePath}, QRCode: {QRCode}, OS: {operatingSystem}, Screen Size: {screenSize}\", Storage: {storageCapacity}GB, RAM: {ramSize}GB, Camera: {cameraQuality}MP, CPU: {cpuType}, Battery: {batteryCapacity}mAh, Tablet: {tablet}";
        }

        public static string Compare(Phone a, Phone b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing Phone: {a.name} vs {b.name}");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Color: {a.color} vs {b.color}");
            sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
            sb.AppendLine($"ID: {a.id} vs {b.id}");
            sb.AppendLine($"Description: {a.description} vs {b.description}");
            sb.AppendLine($"Quantity: {a.quantity} vs {b.quantity}");
            sb.AppendLine($"ImagePath: {a.imagePath} vs {b.imagePath}");
            sb.AppendLine($"QRCode: {a.QRCode} vs {b.QRCode}"); // QRCode is string
            sb.AppendLine($"OS: {a.operatingSystem} vs {b.operatingSystem}");
            sb.AppendLine($"Screen Size: {a.screenSize}\" vs {b.screenSize}\"");
            sb.AppendLine($"Storage: {a.storageCapacity}GB vs {b.storageCapacity}GB");
            sb.AppendLine($"RAM: {a.ramSize}GB vs {b.ramSize}GB");
            sb.AppendLine($"Camera: {a.cameraQuality}MP vs {b.cameraQuality}MP");
            sb.AppendLine($"CPU: {a.cpuType} vs {b.cpuType}");
            sb.AppendLine($"Battery: {a.batteryCapacity}mAh vs {b.batteryCapacity}mAh");
            sb.AppendLine($"Tablet: {a.tablet} vs {b.tablet}"); // Added tablet comparison
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

        public Fold() { }

        // Total properties: 18 (Phone) + 5 (Fold) = 23
        public override void SetData(params object[] parameters)
        {
            if (parameters.Length != 23)
                throw new ArgumentException("Invalid number of parameters for Fold. Expected 23.");

            // Phone properties (0-17)
            name = (string)parameters[0];
            brand = (string)parameters[1];
            model = (string)parameters[2];
            color = (string)parameters[3];
            price = Convert.ToSingle(parameters[4]);
            id = Convert.ToInt32(parameters[5]);
            description = (string)parameters[6];
            quantity = Convert.ToInt32(parameters[7]);
            imagePath = (string)parameters[8];
            QRCode = (string)parameters[9];
            operatingSystem = (string)parameters[10];
            screenSize = Convert.ToSingle(parameters[11]);
            storageCapacity = Convert.ToInt32(parameters[12]);
            ramSize = Convert.ToInt32(parameters[13]);
            cameraQuality = Convert.ToInt32(parameters[14]);
            cpuType = (string)parameters[15];
            batteryCapacity = Convert.ToInt32(parameters[16]);
            tablet = Convert.ToBoolean(parameters[17]);

            // Fold specific properties (18-22)
            foldType = (string)parameters[18];
            hingeMaterial = (string)parameters[19];
            displayType = (string)parameters[20];
            durabilityRating = (string)parameters[21];
            sizeOfOpenedScreen = Convert.ToSingle(parameters[22]);

            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string insertQuery = "INSERT INTO Folds (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                 "operatingSystem, screenSize, storageCapacity, ramSize, cameraQuality, cpuType, batteryCapacity, tablet, " +
                                 "foldType, hingeMaterial, displayType, durabilityRating, sizeOfOpenedScreen) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                 "@operatingSystem, @screenSize, @storageCapacity, @ramSize, @cameraQuality, @cpuType, @batteryCapacity, @tablet, " +
                                 "@foldType, @hingeMaterial, @displayType, @durabilityRating, @sizeOfOpenedScreen)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
                cmd.Parameters.AddWithValue("@QRCode", QRCode);
                cmd.Parameters.AddWithValue("@operatingSystem", operatingSystem);
                cmd.Parameters.AddWithValue("@screenSize", screenSize);
                cmd.Parameters.AddWithValue("@storageCapacity", storageCapacity);
                cmd.Parameters.AddWithValue("@ramSize", ramSize);
                cmd.Parameters.AddWithValue("@cameraQuality", cameraQuality);
                cmd.Parameters.AddWithValue("@cpuType", cpuType);
                cmd.Parameters.AddWithValue("@batteryCapacity", batteryCapacity);
                cmd.Parameters.AddWithValue("@tablet", tablet);
                cmd.Parameters.AddWithValue("@foldType", foldType);
                cmd.Parameters.AddWithValue("@hingeMaterial", hingeMaterial);
                cmd.Parameters.AddWithValue("@displayType", displayType);
                cmd.Parameters.AddWithValue("@durabilityRating", durabilityRating);
                cmd.Parameters.AddWithValue("@sizeOfOpenedScreen", sizeOfOpenedScreen);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void GetData(string in_name)
        {
            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string selectQuery = "SELECT * FROM Folds WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@name", in_name);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Phone properties
                        name = reader["name"].ToString();
                        brand = reader["brand"].ToString();
                        model = reader["model"].ToString();
                        color = reader["color"].ToString();
                        price = Convert.ToSingle(reader["price"]);
                        id = Convert.ToInt32(reader["id"]);
                        description = reader["description"].ToString();
                        quantity = Convert.ToInt32(reader["quantity"]);
                        imagePath = reader["imagePath"].ToString();
                        QRCode = reader["QRCode"].ToString();
                        operatingSystem = reader["operatingSystem"].ToString();
                        screenSize = Convert.ToSingle(reader["screenSize"]);
                        storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                        ramSize = Convert.ToInt32(reader["ramSize"]);
                        cameraQuality = Convert.ToInt32(reader["cameraQuality"]);
                        cpuType = reader["cpuType"].ToString();
                        batteryCapacity = Convert.ToInt32(reader["batteryCapacity"]);
                        tablet = Convert.ToBoolean(reader["tablet"]);

                        // Fold specific properties
                        foldType = reader["foldType"].ToString();
                        hingeMaterial = reader["hingeMaterial"].ToString();
                        displayType = reader["displayType"].ToString();
                        durabilityRating = reader["durabilityRating"].ToString();
                        sizeOfOpenedScreen = Convert.ToSingle(reader["sizeOfOpenedScreen"]);
                    }
                }
                conn.Close();
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Fold Type: {foldType}, Hinge Material: {hingeMaterial}, Display Type: {displayType}, Durability: {durabilityRating}, Opened Screen Size: {sizeOfOpenedScreen}\"";
        }

        public static string Compare(Fold a, Fold b)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Phone.Compare(a, b)); // Calls base class compare
            sb.AppendLine($"Fold Type: {a.foldType} vs {b.foldType}");
            sb.AppendLine($"Hinge Material: {a.hingeMaterial} vs {b.hingeMaterial}");
            sb.AppendLine($"Display Type: {a.displayType} vs {b.displayType}");
            sb.AppendLine($"Durability: {a.durabilityRating} vs {b.durabilityRating}");
            sb.AppendLine($"Opened Screen Size: {a.sizeOfOpenedScreen}\" vs {b.sizeOfOpenedScreen}\"");
            return sb.ToString();
        }
    }

    public class Laptop : Electronics
    {
        public string operatingSystem { get; set; }
        public int storageCapacity { get; set; }
        public int ramSize { get; set; }
        public string graphicsCard { get; set; }
        public string cpuType { get; set; }
        public float screenSize { get; set; }
        public string batteryLife { get; set; } // E.g., "Up to 10 hours"

        public Laptop() { }

        // Total properties: 10 (Electronics) + 7 (Laptop) = 17
        public override void SetData(params object[] parameters)
        {
            if (parameters.Length != 17)
                throw new ArgumentException("Invalid number of parameters for Laptop. Expected 17.");

            name = (string)parameters[0];
            brand = (string)parameters[1];
            model = (string)parameters[2];
            color = (string)parameters[3];
            price = Convert.ToSingle(parameters[4]);
            id = Convert.ToInt32(parameters[5]);
            description = (string)parameters[6];
            quantity = Convert.ToInt32(parameters[7]);
            imagePath = (string)parameters[8];
            QRCode = (string)parameters[9];
            operatingSystem = (string)parameters[10];
            storageCapacity = Convert.ToInt32(parameters[11]);
            ramSize = Convert.ToInt32(parameters[12]);
            graphicsCard = (string)parameters[13];
            cpuType = (string)parameters[14];
            screenSize = Convert.ToSingle(parameters[15]);
            batteryLife = (string)parameters[16];

            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string insertQuery = "INSERT INTO Laptops (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                 "operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                 "@operatingSystem, @storageCapacity, @ramSize, @graphicsCard, @cpuType, @screenSize, @batteryLife)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
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

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void GetData(string in_name) // Corrected method signature
        {
            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string selectQuery = "SELECT * FROM Laptops WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@name", in_name);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["name"].ToString();
                        brand = reader["brand"].ToString();
                        model = reader["model"].ToString();
                        color = reader["color"].ToString();
                        price = Convert.ToSingle(reader["price"]);
                        id = Convert.ToInt32(reader["id"]);
                        description = reader["description"].ToString();
                        quantity = Convert.ToInt32(reader["quantity"]);
                        imagePath = reader["imagePath"].ToString();
                        QRCode = reader["QRCode"].ToString();
                        operatingSystem = reader["operatingSystem"].ToString();
                        storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                        ramSize = Convert.ToInt32(reader["ramSize"]);
                        graphicsCard = reader["graphicsCard"].ToString();
                        cpuType = reader["cpuType"].ToString();
                        screenSize = Convert.ToSingle(reader["screenSize"]);
                        batteryLife = reader["batteryLife"].ToString();
                    }
                }
                conn.Close();
            }
        }

        public override string ToString()
        {
            return $"Laptop: {name}, Brand: {brand}, Model: {model}, Color: {color}, Price: {price:C}, ID: {id}, QRCode: {QRCode}, OS: {operatingSystem}, Storage: {storageCapacity}GB, RAM: {ramSize}GB, Graphics: {graphicsCard}, CPU: {cpuType}, Screen: {screenSize}\", Battery: {batteryLife}";
        }

        public static string Compare(Laptop a, Laptop b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing Laptop: {a.name} vs {b.name}");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Color: {a.color} vs {b.color}");
            sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
            sb.AppendLine($"ID: {a.id} vs {b.id}");
            sb.AppendLine($"Description: {a.description} vs {b.description}");
            sb.AppendLine($"Quantity: {a.quantity} vs {b.quantity}");
            sb.AppendLine($"ImagePath: {a.imagePath} vs {b.imagePath}");
            sb.AppendLine($"QRCode: {a.QRCode} vs {b.QRCode}");
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

    public class GamingLaptop : Laptop // Renamed from GammingLapop
    {
        public string coolingSystem { get; set; }
        public string keyboardType { get; set; } // E.g., "RGB Backlit Mechanical"
        public int frameRate { get; set; } // Max supported or typical FPS

        public GamingLaptop() { }

        // Total properties: 17 (Laptop) + 3 (GamingLaptop) = 20
        public override void SetData(params object[] parameters)
        {
            if (parameters.Length != 20)
                throw new ArgumentException("Invalid number of parameters for GamingLaptop. Expected 20.");

            // Laptop properties (0-16)
            name = (string)parameters[0];
            brand = (string)parameters[1];
            model = (string)parameters[2];
            color = (string)parameters[3];
            price = Convert.ToSingle(parameters[4]);
            id = Convert.ToInt32(parameters[5]);
            description = (string)parameters[6];
            quantity = Convert.ToInt32(parameters[7]);
            imagePath = (string)parameters[8];
            QRCode = (string)parameters[9];
            operatingSystem = (string)parameters[10];
            storageCapacity = Convert.ToInt32(parameters[11]);
            ramSize = Convert.ToInt32(parameters[12]);
            graphicsCard = (string)parameters[13];
            cpuType = (string)parameters[14];
            screenSize = Convert.ToSingle(parameters[15]);
            batteryLife = (string)parameters[16];

            // GamingLaptop specific properties (17-19)
            coolingSystem = (string)parameters[17];
            keyboardType = (string)parameters[18];
            frameRate = Convert.ToInt32(parameters[19]);

            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            // Using GammingLaptops table name as per DDL
            string insertQuery = "INSERT INTO GammingLaptops (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                 "operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife, " +
                                 "coolingSystem, keyboardType, frameRate) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                 "@operatingSystem, @storageCapacity, @ramSize, @graphicsCard, @cpuType, @screenSize, @batteryLife, " +
                                 "@coolingSystem, @keyboardType, @frameRate)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                // Laptop params
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
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

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void GetData(string in_name)
        {
            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            // Using GammingLaptops table name as per DDL
            string selectQuery = "SELECT * FROM GammingLaptops WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@name", in_name);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Laptop properties
                        name = reader["name"].ToString();
                        brand = reader["brand"].ToString();
                        model = reader["model"].ToString();
                        color = reader["color"].ToString();
                        price = Convert.ToSingle(reader["price"]);
                        id = Convert.ToInt32(reader["id"]);
                        description = reader["description"].ToString();
                        quantity = Convert.ToInt32(reader["quantity"]);
                        imagePath = reader["imagePath"].ToString();
                        QRCode = reader["QRCode"].ToString();
                        operatingSystem = reader["operatingSystem"].ToString();
                        storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                        ramSize = Convert.ToInt32(reader["ramSize"]);
                        graphicsCard = reader["graphicsCard"].ToString();
                        cpuType = reader["cpuType"].ToString();
                        screenSize = Convert.ToSingle(reader["screenSize"]);
                        batteryLife = reader["batteryLife"].ToString();

                        // GamingLaptop specific properties
                        coolingSystem = reader["coolingSystem"].ToString();
                        keyboardType = reader["keyboardType"].ToString();
                        frameRate = Convert.ToInt32(reader["frameRate"]);
                    }
                }
                conn.Close();
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Cooling: {coolingSystem}, Keyboard: {keyboardType}, Max FPS: {frameRate}";
        }

        public static string Compare(GamingLaptop a, GamingLaptop b)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Laptop.Compare(a, b)); // Calls base class compare
            sb.AppendLine($"Cooling: {a.coolingSystem} vs {b.coolingSystem}");
            sb.AppendLine($"Keyboard: {a.keyboardType} vs {b.keyboardType}");
            sb.AppendLine($"FPS: {a.frameRate} vs {b.frameRate}");
            return sb.ToString();
        }
    }

    public class TwoInOne : Laptop
    {
        public bool detachableKeyboard { get; set; }
        public string hingeType { get; set; } // E.g., "360-degree", "Surface-style kickstand"

        public TwoInOne() { }

        // Total properties: 17 (Laptop) + 2 (TwoInOne) = 19
        public override void SetData(params object[] parameters)
        {
            if (parameters.Length != 19)
                throw new ArgumentException("Invalid number of parameters for TwoInOne. Expected 19.");

            // Laptop properties (0-16)
            name = (string)parameters[0];
            brand = (string)parameters[1];
            model = (string)parameters[2];
            color = (string)parameters[3];
            price = Convert.ToSingle(parameters[4]);
            id = Convert.ToInt32(parameters[5]);
            description = (string)parameters[6];
            quantity = Convert.ToInt32(parameters[7]);
            imagePath = (string)parameters[8];
            QRCode = (string)parameters[9];
            operatingSystem = (string)parameters[10];
            storageCapacity = Convert.ToInt32(parameters[11]);
            ramSize = Convert.ToInt32(parameters[12]);
            graphicsCard = (string)parameters[13];
            cpuType = (string)parameters[14];
            screenSize = Convert.ToSingle(parameters[15]);
            batteryLife = (string)parameters[16];

            // TwoInOne specific properties (17-18)
            detachableKeyboard = Convert.ToBoolean(parameters[17]);
            hingeType = (string)parameters[18];

            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string insertQuery = "INSERT INTO TwoInOnes (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                 "operatingSystem, storageCapacity, ramSize, graphicsCard, cpuType, screenSize, batteryLife, " +
                                 "detachableKeyboard, hingeType) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                 "@operatingSystem, @storageCapacity, @ramSize, @graphicsCard, @cpuType, @screenSize, @batteryLife, " +
                                 "@detachableKeyboard, @hingeType)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                // Laptop params
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
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

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void GetData(string in_name)
        {
            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string selectQuery = "SELECT * FROM TwoInOnes WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@name", in_name);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Laptop properties
                        name = reader["name"].ToString();
                        brand = reader["brand"].ToString();
                        model = reader["model"].ToString();
                        color = reader["color"].ToString();
                        price = Convert.ToSingle(reader["price"]);
                        id = Convert.ToInt32(reader["id"]);
                        description = reader["description"].ToString();
                        quantity = Convert.ToInt32(reader["quantity"]);
                        imagePath = reader["imagePath"].ToString();
                        QRCode = reader["QRCode"].ToString();
                        operatingSystem = reader["operatingSystem"].ToString();
                        storageCapacity = Convert.ToInt32(reader["storageCapacity"]);
                        ramSize = Convert.ToInt32(reader["ramSize"]);
                        graphicsCard = reader["graphicsCard"].ToString();
                        cpuType = reader["cpuType"].ToString();
                        screenSize = Convert.ToSingle(reader["screenSize"]);
                        batteryLife = reader["batteryLife"].ToString();

                        // TwoInOne specific properties
                        detachableKeyboard = Convert.ToBoolean(reader["detachableKeyboard"]);
                        hingeType = reader["hingeType"].ToString();
                    }
                }
                conn.Close();
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Detachable Keyboard: {detachableKeyboard}, Hinge Type: {hingeType}";
        }

        public static string Compare(TwoInOne a, TwoInOne b)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Laptop.Compare(a, b)); // Calls base class compare
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

        public Cpu() { }

        // Total properties: 10 (Electronics) + 3 (Cpu) = 13
        public override void SetData(params object[] parameters)
        {
            if (parameters.Length != 13)
                throw new ArgumentException("Invalid number of parameters for Cpu. Expected 13.");

            name = (string)parameters[0];
            brand = (string)parameters[1];
            model = (string)parameters[2];
            color = (string)parameters[3]; // Often N/A for CPU, but part of base
            price = Convert.ToSingle(parameters[4]);
            id = Convert.ToInt32(parameters[5]);
            description = (string)parameters[6];
            quantity = Convert.ToInt32(parameters[7]);
            imagePath = (string)parameters[8];
            QRCode = (string)parameters[9];
            cores = Convert.ToInt32(parameters[10]);
            frequencyGHz = Convert.ToSingle(parameters[11]);
            socketType = (string)parameters[12];

            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string insertQuery = "INSERT INTO Cpus (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                 "cores, frequencyGHz, socketType) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                 "@cores, @frequencyGHz, @socketType)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
                cmd.Parameters.AddWithValue("@QRCode", QRCode);
                cmd.Parameters.AddWithValue("@cores", cores);
                cmd.Parameters.AddWithValue("@frequencyGHz", frequencyGHz);
                cmd.Parameters.AddWithValue("@socketType", socketType);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void GetData(string in_name) // Corrected method signature
        {
            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string selectQuery = "SELECT * FROM Cpus WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@name", in_name);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["name"].ToString();
                        brand = reader["brand"].ToString();
                        model = reader["model"].ToString();
                        color = reader["color"].ToString();
                        price = Convert.ToSingle(reader["price"]);
                        id = Convert.ToInt32(reader["id"]);
                        description = reader["description"].ToString();
                        quantity = Convert.ToInt32(reader["quantity"]);
                        imagePath = reader["imagePath"].ToString();
                        QRCode = reader["QRCode"].ToString();
                        cores = Convert.ToInt32(reader["cores"]);
                        frequencyGHz = Convert.ToSingle(reader["frequencyGHz"]);
                        socketType = reader["socketType"].ToString();
                    }
                }
                conn.Close();
            }
        }

        public override string ToString()
        {
            return $"CPU: {name}, Brand: {brand}, Model: {model}, Price: {price:C}, ID: {id}, QRCode: {QRCode}, Cores: {cores}, Frequency: {frequencyGHz}GHz, Socket: {socketType}";
        }


        public static string Compare(Cpu a, Cpu b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing CPU: {a.name} vs {b.name}");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Color: {a.color} vs {b.color}"); // from Electronics
            sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
            sb.AppendLine($"ID: {a.id} vs {b.id}"); // from Electronics
            sb.AppendLine($"Description: {a.description} vs {b.description}"); // from Electronics
            sb.AppendLine($"Quantity: {a.quantity} vs {b.quantity}"); // from Electronics
            sb.AppendLine($"ImagePath: {a.imagePath} vs {b.imagePath}"); // from Electronics
            sb.AppendLine($"QRCode: {a.QRCode} vs {b.QRCode}"); // from Electronics
            sb.AppendLine($"Cores: {a.cores} vs {b.cores}");
            sb.AppendLine($"Frequency: {a.frequencyGHz}GHz vs {b.frequencyGHz}GHz");
            sb.AppendLine($"Socket: {a.socketType} vs {b.socketType}");
            return sb.ToString();
        }
    }

    public class Gpu : Electronics
    {
        public int memoryGB { get; set; }
        public string chipset { get; set; } // E.g., "NVIDIA GeForce RTX 4090", "AMD Radeon RX 7900 XTX"

        public Gpu() { }

        // Total properties: 10 (Electronics) + 2 (Gpu) = 12
        public override void SetData(params object[] parameters)
        {
            if (parameters.Length != 12)
                throw new ArgumentException("Invalid number of parameters for Gpu. Expected 12.");

            name = (string)parameters[0];
            brand = (string)parameters[1];
            model = (string)parameters[2];
            color = (string)parameters[3];
            price = Convert.ToSingle(parameters[4]);
            id = Convert.ToInt32(parameters[5]);
            description = (string)parameters[6];
            quantity = Convert.ToInt32(parameters[7]);
            imagePath = (string)parameters[8];
            QRCode = (string)parameters[9];
            memoryGB = Convert.ToInt32(parameters[10]);
            chipset = (string)parameters[11];

            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string insertQuery = "INSERT INTO Gpus (name, brand, model, color, price, id, description, quantity, imagePath, QRCode, " +
                                 "memoryGB, chipset) " +
                                 "VALUES (@name, @brand, @model, @color, @price, @id, @description, @quantity, @imagePath, @QRCode, " +
                                 "@memoryGB, @chipset)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
                cmd.Parameters.AddWithValue("@QRCode", QRCode);
                cmd.Parameters.AddWithValue("@memoryGB", memoryGB);
                cmd.Parameters.AddWithValue("@chipset", chipset);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override void GetData(string in_name) // Corrected method signature
        {
            string connectionString = "Server=localhost;Database=market;Trusted_Connection=True;";
            string selectQuery = "SELECT * FROM Gpus WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@name", in_name);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name = reader["name"].ToString();
                        brand = reader["brand"].ToString();
                        model = reader["model"].ToString();
                        color = reader["color"].ToString();
                        price = Convert.ToSingle(reader["price"]);
                        id = Convert.ToInt32(reader["id"]);
                        description = reader["description"].ToString();
                        quantity = Convert.ToInt32(reader["quantity"]);
                        imagePath = reader["imagePath"].ToString();
                        QRCode = reader["QRCode"].ToString();
                        memoryGB = Convert.ToInt32(reader["memoryGB"]);
                        chipset = reader["chipset"].ToString();
                    }
                }
                conn.Close();
            }
        }

        public override string ToString()
        {
            return $"GPU: {name}, Brand: {brand}, Model: {model}, Price: {price:C}, ID: {id}, QRCode: {QRCode}, Memory: {memoryGB}GB, Chipset: {chipset}";
        }

        public static string Compare(Gpu a, Gpu b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing GPU: {a.name} vs {b.name}");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Color: {a.color} vs {b.color}"); // from Electronics
            sb.AppendLine($"Price: {a.price:C} vs {b.price:C}");
            sb.AppendLine($"ID: {a.id} vs {b.id}"); // from Electronics
            sb.AppendLine($"Description: {a.description} vs {b.description}"); // from Electronics
            sb.AppendLine($"Quantity: {a.quantity} vs {b.quantity}"); // from Electronics
            sb.AppendLine($"ImagePath: {a.imagePath} vs {b.imagePath}"); // from Electronics
            sb.AppendLine($"QRCode: {a.QRCode} vs {b.QRCode}"); // from Electronics
            sb.AppendLine($"Memory: {a.memoryGB}GB vs {b.memoryGB}GB");
            sb.AppendLine($"Chipset: {a.chipset} vs {b.chipset}");
            return sb.ToString();
        }
    }
}