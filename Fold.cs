using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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
}
