public class Prototype
{
    public string Name { get; set; }

    public Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}