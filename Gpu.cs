using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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