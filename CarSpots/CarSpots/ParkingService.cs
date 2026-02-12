using System;
using System.Collections.Generic;
using System.Text;

namespace CarSpots
{
    public class ParkingService : IParkingService
    {
        private readonly ParkingSpot[] parkingSpots;

        public ParkingService(int spotsCount)
        {
            parkingSpots = new ParkingSpot[spotsCount];
            
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                parkingSpots[i]= new ParkingSpot();
            }
        }
        
        public Vehicle FindVehicle(string licensePlate)
        {
            return parkingSpots.SingleOrDefault(f => f.ParkedVehicle!=null && !string.IsNullOrWhiteSpace(f.ParkedVehicle.LicensePlate) && 
                f.ParkedVehicle.LicensePlate == licensePlate)?.ParkedVehicle;
        }

        public IEnumerable<ParkingSpot> GetAvailableSpots()
        {
            return parkingSpots.Where(f => !f.Occipaied);
        }

        public bool Leave(Vehicle vehicle)
        {
            var spots = parkingSpots.Where(f => f.Occipaied && f.ParkedVehicle == vehicle);
            if(spots==null)
            {
                return false;
            }
            foreach (var item in spots)
            {
                item.Unpark();
            }

            return true;
        }

        public bool Park(Vehicle vehicle)
        {
            if(vehicle==null)
                throw new ArgumentNullException(nameof(vehicle));
            
            var spots = GetFree(vehicle);

            if(spots==null)
            {
                return false;
            }

            foreach (var spot in spots)
            {
                spot.Park(vehicle);
            }
            vehicle.Ticket = new Tiket { LicensePlate = vehicle.LicensePlate, Valid = true };
            return true;
        }

        private List<ParkingSpot> GetFree(Vehicle vehicle)
        {
            List<ParkingSpot> result = new List<ParkingSpot>();
            
            for(int i=0;i<parkingSpots.Length;i++)
            {
                if (!parkingSpots[i].Occipaied && vehicle.SpotRequirement==1)
                {
                    result.Add(parkingSpots[i]);
                    return result;
                }

                int range = vehicle.SpotRequirement;
                if(i+range<parkingSpots.Length && parkingSpots.Skip(i).Take(range).All(f=>!f.Occipaied))
                {
                    result.AddRange(parkingSpots.Skip(i).Take(range));
                    return result;
                }
            }

            return null;
        }
    }
}
