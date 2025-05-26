using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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

