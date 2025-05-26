using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks; // Required for async operations

namespace Market
{
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
            string name, string brand, string model, string color, float price,int id,
            string description, int quantity, string imagePath, string qrCode,
            string operatingSystem, float screenSize, int storageCapacity, int ramSize,
            int cameraQuality, string cpuType, int batteryCapacity, bool tablet)
            : base(name, brand, model, color, price,id, description, quantity, imagePath, qrCode)
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

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public override async Task GetDataAsync(string in_name, string connectionString)
        {
            string selectQuery = "SELECT * FROM Phones WHERE name = @name";

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
                        }
                        // Else: object remains in its current state if not found
                    }
                }
            }
        }

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
}