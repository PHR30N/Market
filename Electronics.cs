using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks; // Required for async operations

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