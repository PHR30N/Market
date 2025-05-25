using System;
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
        public int QRCode { get; set; }
        public Electronics() { }
        public abstract void Data(string in_name);
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
        public int tablet { get; set; }

        public Phone() { }

        public override void Data(string in_name)
        {
            this.name = in_name;
        }

        public static string Compare(Phone a, Phone b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing {a.name} vs {b.name}:");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Color: {a.color} vs {b.color}");
            sb.AppendLine($"Price: {a.price} vs {b.price}");
            sb.AppendLine($"OS: {a.operatingSystem} vs {b.operatingSystem}");
            sb.AppendLine($"Screen Size: {a.screenSize}\" vs {b.screenSize}\"");
            sb.AppendLine($"Storage: {a.storageCapacity}GB vs {b.storageCapacity}GB");
            sb.AppendLine($"RAM: {a.ramSize}GB vs {b.ramSize}GB");
            sb.AppendLine($"Camera: {a.cameraQuality} vs {b.cameraQuality}");
            sb.AppendLine($"CPU: {a.cpuType} vs {b.cpuType}");
            sb.AppendLine($"Battery: {a.batteryCapacity} vs {b.batteryCapacity}");
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

        public static string Compare(Fold a, Fold b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Phone.Compare(a, b));
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
        public string batteryLife { get; set; }

        public Laptop() { }

        public override void Data(string in_name)
        {
            this.name = in_name;
        }

        public static string Compare(Laptop a, Laptop b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing {a.name} vs {b.name}:");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Price: {a.price} vs {b.price}");
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

    public class GammingLapop : Laptop
    {
        public string coolingSystem { get; set; }
        public string keyboardType { get; set; }
        public int frameRate { get; set; }

        public GammingLapop() { }

        public static string Compare(GammingLapop a, GammingLapop b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Laptop.Compare(a, b));
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

        public TwoInOne() { }

        public static string Compare(TwoInOne a, TwoInOne b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Laptop.Compare(a, b));
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

        public override void Data(string in_name)
        {
            this.name = in_name;
        }

        public static string Compare(Cpu a, Cpu b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing CPU: {a.name} vs {b.name}");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Cores: {a.cores} vs {b.cores}");
            sb.AppendLine($"Frequency: {a.frequencyGHz}GHz vs {b.frequencyGHz}GHz");
            sb.AppendLine($"Socket: {a.socketType} vs {b.socketType}");
            sb.AppendLine($"Price: {a.price} vs {b.price}");
            return sb.ToString();
        }
    }

    public class Gpu : Electronics
    {
        public int memoryGB { get; set; }
        public string chipset { get; set; }

        public Gpu() { }

        public override void Data(string in_name)
        {
            this.name = in_name;
        }

        public static string Compare(Gpu a, Gpu b)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comparing GPU: {a.name} vs {b.name}");
            sb.AppendLine($"Brand: {a.brand} vs {b.brand}");
            sb.AppendLine($"Model: {a.model} vs {b.model}");
            sb.AppendLine($"Memory: {a.memoryGB}GB vs {b.memoryGB}GB");
            sb.AppendLine($"Chipset: {a.chipset} vs {b.chipset}");
            sb.AppendLine($"Price: {a.price} vs {b.price}");
            return sb.ToString();
        }
    }
}