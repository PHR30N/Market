using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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
