namespace xUnitDemo;

public class Calculator : ICalculator
{
    public decimal Add(decimal a, decimal b)
    {
        return 0;
    }

    public decimal Subtract(decimal a, decimal b)
    {
        throw new NotImplementedException();
    }

    public decimal Multiply(decimal a, decimal b)
    {
        return a;
    }

    public decimal Divide(decimal a, decimal b)
    {
        throw new NotImplementedException();
    }
}