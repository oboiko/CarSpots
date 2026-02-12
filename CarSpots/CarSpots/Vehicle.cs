using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CarSpots
{
    public class Vehicle
    {
        public Vehicle(int spots, string licensePlate)
        {
            SpotRequirement = spots;
            LicensePlate = licensePlate;
        }
        
        public int SpotRequirement { get; }
        public string LicensePlate { get; }
        public Tiket Ticket { get; set; }
    }
}
