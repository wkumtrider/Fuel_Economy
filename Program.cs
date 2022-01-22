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

            //Displays initial menu
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
                        List<VehicleData> resultsSearchByVehicle = vehicalSpecs.Where(vehicalSpecs => vehicalSpecs.VehicleMake.ToUpper() == vehicleMake && vehicalSpecs.VehicleModel.ToUpper() == vehicleModle
                        && vehicalSpecs.VehicleYear.ToString() == vehicleYear).ToList();
                        if (resultsSearchByVehicle.Count > 0)
                        {
                            PrintVehicleInfo(resultsSearchByVehicle);
                            Console.WriteLine("\n Enter '1' to continue an new search or 'q' to quit.");
                            var newsearch = Console.ReadLine().ToLower();
                            if (newsearch != "1")
                            {
                                { Environment.Exit(0); }
                            }
                        }
                        else //No vehicles found matching search criteria
                        {
                            Console.WriteLine("No vehicles found matching your criteria");
                            Console.WriteLine("\n Enter '1' to continue an new search or 'q' to quit.");
                            var newsearch = Console.ReadLine().ToLower();
                            if (newsearch != "1")
                            {
                                { Environment.Exit(0); }
                            }
                        }

                        break;

                    //Searches for a vehicle by a specified fuel economy
                    case "2":
                        Console.WriteLine("Enter the desired city fuel economy: ");
                        int desiredCityMPG = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the desired highway fuel economy: ");
                        int desiredHighwayMPG = int.Parse(Console.ReadLine());

                        // Search and print logic here
                        List<VehicleData> resultsSearchByMPG = vehicalSpecs.Where(vehicalSpecs => vehicalSpecs.VehicleFuelEconomyCity == desiredCityMPG && vehicalSpecs.VehicleFuelEconomyHW == desiredHighwayMPG).ToList();
                        if (resultsSearchByMPG.Count > 0)
                        {
                            PrintVehicleInfo(resultsSearchByMPG);
                            Console.WriteLine("\n Enter '1' to continue an new search or 'q' to quit.");
                            var newsearch = Console.ReadLine().ToLower();
                            if (newsearch != "1")
                            {
                                { Environment.Exit(0); }
                            }
                        }
                        else //No vehicles found matching search criteria
                        {
                            Console.WriteLine("No vehicles found matching your criteria");
                            Console.WriteLine("\n Enter '1' to continue an new search or 'q' to quit.");
                            var newsearch = Console.ReadLine().ToLower();
                            if (newsearch != "1")
                            {
                                { Environment.Exit(0); }
                            }
                        }

                        break;

                    case "3":
                        Console.WriteLine("Please enter vehicle make to be added to the database");
                        var vehcileMakeToBeAdded = Console.ReadLine();
                        Console.WriteLine("Enter vehicle model to be added to the database");
                        var vehicleModelToBeAdded = Console.ReadLine();
                        Console.WriteLine("Enter vehicle year to be added to the database");
                        var vehicleYearToBeAdded = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter vehicle MPG in the City");
                        var vehicleMPGCityToBeAdded = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter vehicle MPG Highway to be added to the database");
                        var vehicleMPGHightwayToBeAdded = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter vehicle MPG Combined to be added to the database");
                        var vehicleMPGCombinedToBeAdded = int.Parse(Console.ReadLine());

                        VehicleData vehicleDataToAdd = new VehicleData
                        {
                            VehicleMake = vehcileMakeToBeAdded,
                            VehicleModel = vehicleModelToBeAdded,
                            VehicleYear = vehicleYearToBeAdded,
                            VehicleFuelEconomyCity = vehicleMPGCityToBeAdded,
                            VehicleFuelEconomyHW = vehicleMPGHightwayToBeAdded,
                            VehicleFuelEconomyCombined = vehicleMPGCombinedToBeAdded
                        };
                        WriteVehicleData(vehicleDataToAdd);

                        Console.WriteLine("Enter '3'if you would like to enter another vehicle into the database? Or Q to quit");
                        var enterNewVehicleAgain = Console.ReadLine().ToLower();
                        if (enterNewVehicleAgain != "3")
                        {
                            { Environment.Exit(0); }
                        }

                        break;
                }
            }
        }

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

        private static void WriteVehicleData(VehicleData vehicleDataToAdd)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "FuelEconomy.csv");
            using (var writer = File.AppendText(fileName))
            {
                string vehicleDateToWriteToFile = ($"{vehicleDataToAdd.VehicleMake},{vehicleDataToAdd.VehicleModel}, {vehicleDataToAdd.VehicleYear}, {vehicleDataToAdd.VehicleFuelEconomyCity}, {vehicleDataToAdd.VehicleFuelEconomyHW}, {vehicleDataToAdd.VehicleFuelEconomyCombined}");
                writer.WriteLine(vehicleDateToWriteToFile);
            }
        }

        private static void PrintVehicleInfo(List<VehicleData> vehicles)
        {
            Console.WriteLine("\nVehicles matching your search criteria: ");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Make: {vehicle.VehicleMake}, Model: {vehicle.VehicleModel}, City MPG: {vehicle.VehicleFuelEconomyCity}, Highway MPG: {vehicle.VehicleFuelEconomyHW}");
            }
        }
    }
}