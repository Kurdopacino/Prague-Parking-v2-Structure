namespace Pragueparkingv2.Klasser
{
    public class Garage
    {
        private string[] parkingSpots;

        public Garage(int size)
        {
            parkingSpots = new string[size];
        }

        public void ParkVehicle()
        {
            Console.Write("Enter vehicle type (CAR/MC): ");
            string vehicleType = Console.ReadLine().ToUpper();

            if (vehicleType != "CAR" && vehicleType != "MC")
            {
                Console.WriteLine("Invalid vehicle type.");
                return;
            }

            Console.Write("Enter registration number: ");
            string registration = Console.ReadLine();

            if (!Vehicle.IsValidRegistration(registration))
            {
                Console.WriteLine("Invalid registration number format.");
                return;
            }

            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (string.IsNullOrEmpty(parkingSpots[i]))
                {
                    parkingSpots[i] = $"{vehicleType}#{registration}";
                    Console.WriteLine($"Vehicle parked at spot {i + 1}.");
                    return;
                }
                else if (vehicleType == "MC" && parkingSpots[i].StartsWith("MC#"))
                {
                    if (parkingSpots[i].Split('|').Length < 2)
                    {
                        parkingSpots[i] += $"|{vehicleType}#{registration}";
                        Console.WriteLine($"Motorcycle double-parked at spot {i + 1}.");
                        return;
                    }
                }
            }
            Console.WriteLine("No available parking spots.");
        }

        public void RetrieveVehicle()
        {
            Console.Write("Enter reg number to retrieve vehicle: ");
            string registration = Console.ReadLine();

            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (!string.IsNullOrEmpty(parkingSpots[i]) && parkingSpots[i].Contains(registration))
                {
                    parkingSpots[i] = parkingSpots[i].Replace(registration, "").Trim('|');
                    Console.WriteLine($"Vehicle with reg number {registration} retrieved from spot {i + 1}.");
                    if (string.IsNullOrEmpty(parkingSpots[i])) parkingSpots[i] = "";
                    return;
                }
            }
            Console.WriteLine("Vehicle not found.");
        }

        public void MoveVehicle()
        {
            Console.Write("Enter current parking spot number (1-100): ");
            if (int.TryParse(Console.ReadLine(), out int currentSpot) && currentSpot >= 1 && currentSpot <= 100)
            {
                int currentIndex = currentSpot - 1;

                if (!string.IsNullOrEmpty(parkingSpots[currentIndex]))
                {
                    Console.Write("Enter new parking spot number (1-100): ");
                    if (int.TryParse(Console.ReadLine(), out int newSpot) && newSpot >= 1 && newSpot <= 100)
                    {
                        int newIndex = newSpot - 1;

                        if (string.IsNullOrEmpty(parkingSpots[newIndex]))
                        {
                            parkingSpots[newIndex] = parkingSpots[currentIndex];
                            parkingSpots[currentIndex] = "";
                            Console.WriteLine($"Vehicle moved from spot {currentSpot} to {newSpot}.");
                        }
                        else
                        {
                            Console.WriteLine("The specified spot is occupied.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid spot.");
                    }
                }
                else
                {
                    Console.WriteLine("No vehicle found at the current spot.");
                }
            }
            else
            {
                Console.WriteLine("Invalid spot.");
            }
        }

        public void SearchVehicle()
        {
            Console.Write("Enter reg number to search: ");
            string registration = Console.ReadLine();

            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (parkingSpots[i].Contains(registration))
                {
                    Console.WriteLine($"Vehicle found at spot {i + 1}: {parkingSpots[i]}.");
                    return;
                }
            }
            Console.WriteLine("Vehicle not found.");
        }

        public void ViewParkingStatus()
        {
            Console.WriteLine("Parking Status:");
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                string status = string.IsNullOrEmpty(parkingSpots[i]) ? "Empty" : parkingSpots[i];
                Console.WriteLine($"Spot {i + 1}: {status}");
            }
        }

        public void SaveParkingData() => GarageFileHandler.Save(parkingSpots);

        public void LoadParkingData() => parkingSpots = GarageFileHandler.Load(parkingSpots.Length);
    }
}
          
