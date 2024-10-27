/*
    Prototype:
    Creates new objects by copying an existing instance rather than creating from scratch.
    Example:
    A Prototype object can be cloned using a memberwise copy.
*/

public class Prototype
{
    public string Name { get; set; }

    public Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}