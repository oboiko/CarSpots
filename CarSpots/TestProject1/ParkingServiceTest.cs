using CarSpots;

namespace TestProject1
{
    public class ParkingServiceTest
    {
        private IParkingOperation _service = new ParkingService();

        [Fact]
        public void ParkTest()
        {
            Assert.True(_service.GetAvailableSpots().Count() == 60);

            Vehicle motorcycle = new Vehicle(1, "Motorcycle");
            Vehicle car = new Vehicle(1, "Car");
            Vehicle truck = new Vehicle(2, "Truck");

            _service.Park(motorcycle);
            _service.Park(car);
            _service.Park(truck);

            var spacesAvailable = _service.GetAvailableSpots();
            Assert.True(_service.GetAvailableSpots().Count() == 56);
            _service.Leave(truck);
            Assert.True(_service.GetAvailableSpots().Count() == 58);
            Assert.NotNull(_service.FindVehicle(car.LicensePlate));
        }
    }
}
