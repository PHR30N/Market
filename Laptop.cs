using System;

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