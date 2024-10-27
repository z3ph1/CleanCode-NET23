/*
    Facade:
    Provides a simplified interface to a complex subsystem.
    Example:
    A Car class uses a Facade (Engine) to hide the complexity of starting the engine.
*/

public class Engine
{
    public void Start() => Console.WriteLine("Engine started");
}

public class Car
{
    private Engine _engine = new Engine();
    
    public void StartCar() => _engine.Start();
}