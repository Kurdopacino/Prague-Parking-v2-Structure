using System.Text.RegularExpressions;

namespace Pragueparkingv2.Klasser
{
    public class Vehicle
    {
        public string Type { get; }
        public string RegistrationNumber { get; }

        public Vehicle(string type, string registrationNumber)
        {
            Type = type.ToUpper();
            RegistrationNumber = registrationNumber;
        }

        public static bool IsValidRegistration(string registration)
        {
            string pattern = @"^[A-Za-z]{1,2}[0-9]{1,4}[A-Za-z]{0,2}$";
            return Regex.IsMatch(registration, pattern);
        }
    }
}