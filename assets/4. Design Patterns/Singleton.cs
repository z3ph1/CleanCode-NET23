/*
    Singleton:
    Ensures a class has only one instance and provides a global point of access to it.
    Example:
    A Singleton instance can be accessed globally, ensuring only one instance of a resource exists.
*/

public class Singleton
{
    private static Singleton _instance;
    private Singleton() {}

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }
}