public class EuropeanPlug
{
    public void Connect() => Console.WriteLine("Connecting European plug");
}

public interface IUSPlug
{
    void PlugIn();
}

public class USPlugAdapter : IUSPlug
{
    private EuropeanPlug _plug;
    
    public USPlugAdapter(EuropeanPlug plug)
    {
        _plug = plug;
    }
    
    public void PlugIn() => _plug.Connect();
}