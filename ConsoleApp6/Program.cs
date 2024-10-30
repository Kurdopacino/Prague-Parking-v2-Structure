using System;

namespace Pragueparkingv2.Klasser
{

 

class Program
    {
        static void Main()
        {
            Garage garage = new Garage(100);
            garage.LoadParkingData();

            while (true)
            {
                Console.Clear();
                DisplayWelcomeScreen();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        garage.ParkVehicle();
                        break;
                    case "2":
                        garage.RetrieveVehicle();
                        break;
                    case "3":
                        garage.MoveVehicle();
                        break;
                    case "4":
                        garage.SearchVehicle();
                        break;
                    case "5":
                        garage.ViewParkingStatus();
                        break;
                    case "6":
                        garage.SaveParkingData();
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }

        static void DisplayWelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
  _____                              _____           _    _                    ___  
 |  __ \                            |  __ \         | |  (_)                  |__ \ 
 | |__) | __ __ _  __ _ _   _  ___  | |__) |_ _ _ __| | ___ _ __   __ _  __   __ ) |
 |  ___/ '__/ _` |/ _` | | | |/ _ \ |  ___/ _` | '__| |/ / | '_ \ / _` | \ \ / // / 
 | |   | | | (_| | (_| | |_| |  __/ | |  | (_| | |  |   <| | | | | (_| |  \ V // /_ 
 |_|   |_|  \__,_|\__, |\__,_|\___| |_|   \__,_|_|  |_|\_\_|_| |_|\__, |   \_/|____|
                   __/ |                                           __/ |            
                  |___/                                           |___/  
        ");
            Console.ResetColor();
            Console.WriteLine("Welcome to Prague Parking v2 ");
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. Retrieve Vehicle");
            Console.WriteLine("3. Move Vehicle");
            Console.WriteLine("4. Search Vehicle by Reg No");
            Console.WriteLine("5. View Current Parking Status");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
        }
    }
}

