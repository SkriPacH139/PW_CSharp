namespace PW_13
{
    internal class CarFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle() => new Car();
    }
}
