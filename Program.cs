using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;


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

           
            /*VehicleData vehicledata = new VehicleData();
            vehicledata.VehicleMake = "Ford";
            vehicledata.VehicleModel = "Mustang";
            vehicledata.VehicleYear = 2015;
            vehicledata.VehicleTrans = "Manual";
            vehicledata.VehicleEngine = 8;
            Console.WriteLine(vehicledata.VehicleModel);*/

            StringBuilder menu = new StringBuilder();
            menu.Append("\n");
            menu.Append("\n");
            menu.Append("\nWelcome to the Fuel Economy Database.");
            menu.Append("\nThis database allows you to look up the fuel economy of vehciles from 2005 to 2017.");
            menu.Append("\nTYou can also enter a fuel economy and return a list of vehicles that meet the request!");
            menu.Append("\n----------------------------");
            menu.Append("\nTo search by vehicle, enter 1.");
            menu.Append("\nTo seacrch by fuel economy, press 2");
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
                        PrintList(fileContents);
                        Console.WriteLine(fileContents);
                        Console.WriteLine(menu.ToString());

                        break;
                    //case "2":
                        

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
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    VehicleData vehicle = new VehicleData();
                    string[] value = line.Split(',');

                    //int parseInt;
                    //if (int.TryParse(value[4], out parseInt))
                   // {
                        //vehicle.VehicleMake = parseInt;
                    //}
                    vehicle.VehicleModel = value[1];
                    vehicle.VehicleTrans = value[2];
                    //vehicle.VehicleFuelEconomy = value[3];
                    //vehicle.VehicleEngine = value[5];
                    
                    vehicleData.Add(vehicle);
                }
            }
            return vehicleData;
        }


        //Write to file (will need to add data values)
        private static void WriteTitanicData(List<VehicleData> fileContents)
        {
            using(var writer = File.AppendText("FuelEconomy.csv"))
            {
                writer.WriteLine("VehicleMake, VehicleModel,");
                foreach (var item in fileContents)
                {
                    writer.WriteLine(item.VehicleMake + "," + item.VehicleModel);
                }
            }
        }
       
        private static void PrintList(List<VehicleData> albums)
        {
            foreach (var album in albums)
            {
                Console.WriteLine(album.ToString());
            }
        }

    }
}