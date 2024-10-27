public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Car();
}

public class BikeFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Bike();
}