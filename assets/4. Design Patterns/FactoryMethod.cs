/*
    Factory Method:
    Creates objects without specifying the exact class that will be created.
    Example:
    A VehicleFactory creates either a Car or a Bike object based on the derived factory.
*/

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