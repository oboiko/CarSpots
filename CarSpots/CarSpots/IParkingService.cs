using System;
using System.Collections.Generic;
using System.Text;

namespace CarSpots
{
    public interface IParkingOperation
    {
        public bool Park(Vehicle vehicle);
        public bool Leave(Vehicle vehicle);
        public IEnumerable<ParkingSpot> GetAvailableSpots();
        public Vehicle FindVehicle(string licensePlate);

    }
}
