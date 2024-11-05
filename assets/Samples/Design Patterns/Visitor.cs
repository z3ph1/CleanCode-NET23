/*
    Visitor:
    Represents an operation to be performed on elements of an object structure without changing their classes.
    Example:
    A Visitor object performs operations on ConcreteElement objects without modifying their structure.
*/

public interface IVisitor
{
    void Visit(Element element);
}

public class ConcreteVisitor : IVisitor
{
    public void Visit(Element element) => Console.WriteLine("Visiting element");
}

public abstract class Element
{
    public abstract void Accept(IVisitor visitor);
}

public class ConcreteElement : Element
{
    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}