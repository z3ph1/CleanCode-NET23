/*
    Observer:
    Defines a one-to-many relationship where a change in one object notifies all dependent objects.
    Example:
    An Observer object is notified when a Subject undergoes a state change.
*/

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