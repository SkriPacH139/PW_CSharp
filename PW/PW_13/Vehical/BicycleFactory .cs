namespace PW_13
{
    internal class BicycleFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle() => new Bicycle();
    }
}
