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
            var specs = ReadAlbumData(fileName);
           // Console.WriteLine(fileContents);

            /*VehicleData vehicledata = new VehicleData();
            album.AlbumTitle = "So";
            album.ArtistName = "Peter Gabriel";
            album.Genre = "progressive pop";
            album.YearReleased = 1986;
            album.OnLoan = false;
            album.Borrower = "";
            Console.WriteLine(album.AlbumTitle);*/

            StringBuilder menu = new StringBuilder();
            menu.Append("\n");
            menu.Append("\n");
            menu.Append("\nWelcome to the Fuel Economy Database.");
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
        public static List<VehicleData> ReadAlbumData(string fileName)
        {
            var albumData = new List<VehicleData>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    VehicleData album = new VehicleData();
                    string[] value = line.Split(',');

                    //int parseInt;
                    //if (int.TryParse(value[4], out parseInt))
                   // {
                        //album.VehicleMake = parseInt;
                    //}
                    album.VehicleModel = value[1];
                    album.VehicleTrans = value[2];
                    //album.VehicleFuelEconomy = value[3];
                    //album.OnLoan = value[5];
                    //album.Borrower = value[6];

                    albumData.Add(album);
                }
            }
            return albumData;
        }


        //Write to file (will need to add data values)
        private static void WriteTitanicData(List<VehicleData> fileContents)
        {
            using(var writer = File.AppendText("FuelEconomy.csv"))
            {
                writer.WriteLine("ArtistName, AlbumTitle,");
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