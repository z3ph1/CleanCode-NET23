public interface IObserver
{
    void Update();
}

public class Subject
{
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer) => _observers.Add(observer);
    
    public void Notify()
    {
        foreach (var observer in _observers)
            observer.Update();
    }
}

public class ConcreteObserver : IObserver
{
    public void Update() => Console.WriteLine("Observer updated!");
}