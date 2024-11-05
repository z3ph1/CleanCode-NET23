/*
    Chain of Responsibility:
    Passes a request along a chain of handlers, where each handler decides whether to process the request.
    Example:
    A ConcreteHandler1 class handles requests under a certain threshold or forwards them along the chain.
*/

public abstract class Handler
{
    protected Handler _next;

    public void SetNext(Handler next) => _next = next;

    public abstract void HandleRequest(int request);
}

public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 10)
            Console.WriteLine("Handled by Handler1");
        else
            _next?.HandleRequest(request);
    }
}