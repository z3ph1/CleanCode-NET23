public interface IComponent
{
    void Operation();
}

public class Leaf : IComponent
{
    public void Operation() => Console.WriteLine("Leaf operation");
}

public class Composite : IComponent
{
    private List<IComponent> _children = new List<IComponent>();

    public void Add(IComponent component) => _children.Add(component);

    public void Operation()
    {
        foreach (var child in _children)
        {
            child.Operation();
        }
    }
}