using System;
using System.Collections.Generic;
using System.Text;

namespace CarSpots
{
    public class ParkingSpot
    {
        public bool Occipaied { get; private set; }
        public Vehicle ParkedVehicle { get; private set; }

        public void Park(Vehicle vehicle)
        {
            if(Occipaied)
            {
                throw new InvalidOperationException("Already occipied");
            }

            ParkedVehicle = vehicle;
            Occipaied = true;
        }

        public void Unpark()
        {
            Occipaied = false;
            ParkedVehicle = null;
        }
    }
}
