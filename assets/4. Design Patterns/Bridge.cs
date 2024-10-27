/*
    Bridge:
    Decouples an abstraction from its implementation, allowing them to vary independently.
    Example:
    A TV remote interacts with a TV using a bridge between different remote interfaces and devices.
*/

public interface IRemote
{
    void On();
    void Off();
}

public class TVRemote : IRemote
{
    public void On() => Console.WriteLine("TV is ON");
    public void Off() => Console.WriteLine("TV is OFF");
}

public abstract class Device
{
    protected IRemote _remote;
    
    protected Device(IRemote remote)
    {
        _remote = remote;
    }
    
    public abstract void TogglePower();
}

public class Television : Device
{
    public Television(IRemote remote) : base(remote) {}
    
    public override void TogglePower()
    {
        _remote.On();
        _remote.Off();
    }
}