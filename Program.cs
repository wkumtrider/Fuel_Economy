using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace FuelEconomy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find the file
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "FuelEconomy.csv");
            var specs = ReadVehicleData(fileName);


            StringBuilder menu = new StringBuilder();
            menu.Append("\n");
            menu.Append("\n");
            menu.Append("\nWelcome to the Fuel Economy Database.");
            menu.Append("\nThis database allows you to look up the fuel economy of vehicles from 2005 to 2017.");
            menu.Append("\nYou can also enter a fuel economy and return a list of vehicles that meet the request!");
            menu.Append("\n----------------------------");
            menu.Append("\nTo search by vehicle, enter 1.");
            menu.Append("\nTo search by fuel economy, press 2");
            menu.Append("\nTo add a vehicle and it's specs, press 3");
            menu.Append("\n----------------------------");
            menu.Append("\nEnter Q to quit");

            Console.WriteLine(menu.ToString());

            var fileContents = specs;
            var input = Console.ReadLine();
            while (input.ToLower() != "q")
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter vehicle make");
                        Console.ReadLine();
                        Console.WriteLine("Enter vehicle model: ");
                        Console.ReadLine();
                        Console.WriteLine("Enter vehicle year: ");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Enter the desired city fuel economy: ");
                        Console.ReadLine();
                        Console.WriteLine("Enter the desired highway fuel economy: ");
                        Console.ReadLine();
                        break;

                }
            }
        }

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

        private static void PrintList(List<VehicleData> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Make: {vehicle.VehicleMake}, Model: {vehicle.VehicleModel}");
            }
        }

    }
}