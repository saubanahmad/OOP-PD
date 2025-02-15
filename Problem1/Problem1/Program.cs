using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Program
    {
        static List<Ship> ships = new List<Ship>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\n Menu:\n 1. Add Ship\n 2. View Ship Position\n 3. View Ship Serial Number\n 4. Change Ship Position\n 5. Exit\nEnter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddShip();
                        break;
                    case 2:
                        Findlocation();
                        break;
                    case 3:
                        ViewShipSerialNumber();
                        break;
                    case 4:
                        ChangeShipLocation();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
        static void AddShip()
        {
            Console.Write("Enter Ship Number: ");
            string serialnumber = Console.ReadLine();

            Console.WriteLine("Enter Ship Latitude:");
            Console.Write("Enter Latitude's Degree: ");
            int degreelat = int.Parse(Console.ReadLine());

            Console.Write("Enter Latitude's Minutes: ");
            float minuteslat = float.Parse(Console.ReadLine());
            
            Console.Write("Enter Latitude's Direction: ");
            char directionlat = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Ship Longitude:");
            Console.Write("Enter Longitude's Degree: ");
            int degreelong = int.Parse(Console.ReadLine());

            Console.Write("Enter Longitude's Minutes: ");
            float minuteslong = float.Parse(Console.ReadLine());

            Console.Write("Enter Longitude's Direction: ");
            char directionlong = char.Parse(Console.ReadLine());

            Ship s = new Ship(serialnumber, degreelong, minuteslong, directionlong, degreelat, minuteslat, directionlat);
            ships.Add(s);
            Console.WriteLine("Ship added successfully!");
        }

        static void Findlocation()
        {
            Console.WriteLine("Enter Ship Number: ");
            string serialnumber = Console.ReadLine();
            foreach (Ship ship in ships)
            {
                if (ship.SerialNumber == serialnumber)
                {
                    Console.WriteLine("Ship is at " + ship.shiplocationlat.Degrees + "\u00b0" + ship.shiplocationlat.Minutes + "\'" + ship.shiplocationlat.Direction + " and " + ship.shiplocationlong.Degrees + "\u00b0" + ship.shiplocationlong.Minutes + "\'" + ship.shiplocationlong.Direction);
                }
                else
                {
                    Console.WriteLine("Ship Not Found");
                }

            }
        }

        static void ViewShipSerialNumber()
        {
            Console.WriteLine("Enter Ship Latitude:");
            Console.Write("Enter Latitude's Degree: ");
            int degreelat = int.Parse(Console.ReadLine());

            Console.Write("Enter Latitude's Minutes: ");
            float minuteslat = float.Parse(Console.ReadLine());

            Console.Write("Enter Latitude's Direction: ");
            char directionlat = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Ship Longitude:");
            Console.Write("Enter Longitude's Degree: ");
            int degreelong = int.Parse(Console.ReadLine());

            Console.Write("Enter Longitude's Minutes: ");
            float minuteslong = float.Parse(Console.ReadLine());

            Console.Write("Enter Longitude's Direction: ");
            char directionlong = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Latitude: ");
            Ship s1 = new Ship(degreelong, minuteslong, directionlong, degreelat, minuteslat, directionlat);
            foreach (Ship ship in ships)
            {
                if (ship.shiplocationlat.Degrees == s1.shiplocationlat.Degrees &&
                    ship.shiplocationlat.Minutes == s1.shiplocationlat.Minutes &&
                    ship.shiplocationlat.Direction == s1.shiplocationlat.Direction &&
                    ship.shiplocationlong.Degrees == s1.shiplocationlong.Degrees &&
                    ship.shiplocationlong.Minutes == s1.shiplocationlong.Minutes &&
                    ship.shiplocationlong.Direction == s1.shiplocationlong.Direction)
                {
                    Console.WriteLine("Ship's Serial Number is: " + ship.SerialNumber);
                }
                else
                {
                    Console.WriteLine("Ship not found!");
                }
            }
        }
        static void ChangeShipLocation()
        {
            Console.Write("Enter Ship Serial Number whose location you want to change: ");
            string serialNumber = Console.ReadLine();
            Ship ship = ships.Find(s => s.SerialNumber == serialNumber);
            if (ship != null)
            {
                Console.WriteLine("Enter new Ship Latitude:");
                Angle newLatitude = GetAngleInput();

                Console.WriteLine("Enter new Ship Longitude:");
                Angle newLongitude = GetAngleInput();

                ship.shiplocationlat = newLatitude;
                ship.shiplocationlong = newLongitude;

                Console.WriteLine("Ship location updated successfully!");
            }
            else
            {
                Console.WriteLine("Ship not found!");
            }
        }

        static Angle GetAngleInput()
        {
            Console.Write("Enter Degrees: ");
            int degrees = int.Parse(Console.ReadLine());
            Console.Write("Enter Minutes: ");
            float minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Direction: ");
            char direction = char.Parse(Console.ReadLine().ToUpper());
            return new Angle(degrees, minutes, direction);
        }
    }
}
