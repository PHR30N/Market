using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
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
