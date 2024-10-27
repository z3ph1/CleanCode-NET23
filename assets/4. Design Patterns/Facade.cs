public class Engine
{
    public void Start() => Console.WriteLine("Engine started");
}

public class Car
{
    private Engine _engine = new Engine();
    
    public void StartCar() => _engine.Start();
}