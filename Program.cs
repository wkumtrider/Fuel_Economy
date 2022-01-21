using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FuelEconomy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Find the file
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "FuelEconomy.csv");
            var vehicalSpecs = ReadVehicleData(fileName);
            Menu.DisplayMenu();
            var input = Console.ReadLine();
            while (input.ToLower() != "q")
            {
                switch (input)
                {
                    //Searches for a specified vehicle by make, model and year
                    case "1":
                        Console.WriteLine("Enter vehicle make");
                        var vehicleMake = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter vehicle model: ");
                        var vehicleModle = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter vehicle year: ");
                        var vehicleYear = Console.ReadLine();

                        // Search and print logic here
                        List<VehicleData> results = vehicalSpecs.Where(vehicalSpecs => vehicalSpecs.VehicleMake.ToUpper() == vehicleMake && vehicalSpecs.VehicleModel.ToUpper() == vehicleModle
                        && vehicalSpecs.VehicleYear.ToString() == vehicleYear).ToList();
                        if (results.Count > 0)
                        {
                            PrintVehicleInfo(results);
                        }
                        else
                            Console.WriteLine("No vehicles found matching your criteria\n");
                        Menu.DisplayMenu();
                        break;

                    //Searches for a vehicle by a specified fuel economy
                    case "2":
                        Console.WriteLine("Enter the desired city fuel economy: ");
                        Console.ReadLine();
                        Console.WriteLine("Enter the desired highway fuel economy: ");
                        Console.ReadLine();
                        break;
                }
            }
        }

        //TODO: Not getting mpg values
        //Read from the file
        public static List<VehicleData> ReadVehicleData(string fileName)
        {
            var vehicleData = new List<VehicleData>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    VehicleData vehicle = new VehicleData();
                    string[] value = line.Split(',');

                    //int parseInt;
                    //if (int.TryParse(value[4], out parseInt))
                    // {
                    //vehicle.VehicleMake = parseInt;
                    //}

                    vehicle.VehicleMake = value[0];
                    vehicle.VehicleModel = value[1];
                    int parseInt;
                    if (int.TryParse(value[2], out parseInt))
                    {
                        vehicle.VehicleYear = parseInt;
                    }
                    int parseInt1;
                    if (int.TryParse(value[3], out parseInt1))
                    {
                        vehicle.VehicleFuelEconomyCity = parseInt1;
                    }
                    int parseInt2;
                    if (int.TryParse(value[4], out parseInt2))
                    {
                        vehicle.VehicleFuelEconomyHW = parseInt2;
                    }

                    vehicleData.Add(vehicle);
                }
            }
            return vehicleData;
        }

        //TODO: We are getting the CSV file loaded but we need to write the value out I guess?
        // Need to do a search and print out the out put?

        //Write to file (will need to add data values)
        // Is this appending to the csv?
        private static void WriteVehicleData(List<VehicleData> fileContents)
        {
            using (var writer = File.AppendText("FuelEconomy.csv"))
            {
                writer.WriteLine("VehicleMake, VehicleModel,");
                foreach (var item in fileContents)
                {
                    writer.WriteLine(item.VehicleMake + "," + item.VehicleModel);
                }
            }
        }

        private static void PrintVehicleInfo(List<VehicleData> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Make: {vehicle.VehicleMake}, Model: {vehicle.VehicleModel}");
            }
        }
    }
}