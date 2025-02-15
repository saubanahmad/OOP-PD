using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Ship
    {
        public string SerialNumber;
        public Angle shiplocationlong;
        public Angle shiplocationlat;
        public Ship(string serialnumber, int degreelong, float minuteslong, char directionlong, int degreelat, float minuteslat, char directionlat)
        {
            SerialNumber = serialnumber;
            shiplocationlat = new Angle(degreelat, minuteslat, directionlat);
            shiplocationlong = new Angle(degreelong, minuteslong, directionlong);


        }

        public Ship(int degreelong, float minuteslong, char directionlong, int degreelat, float minuteslat, char directionlat)
        {
            shiplocationlat = new Angle(degreelat, minuteslat, directionlat);
            shiplocationlong = new Angle(degreelong, minuteslong, directionlong);

        }

    }
}
