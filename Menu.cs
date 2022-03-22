using System;
using System.Collections.Generic;
using System.Text;

namespace FuelEconomy
{
    public class Menu
    {
        public static void DisplayMenu()
        {
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
        }
    }
}
