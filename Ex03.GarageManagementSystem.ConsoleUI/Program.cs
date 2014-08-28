using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            GarageUI garageUI = new GarageUI();
            garageUI.StartGarageApplication();

            // wait for enter
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }        
    }
}
