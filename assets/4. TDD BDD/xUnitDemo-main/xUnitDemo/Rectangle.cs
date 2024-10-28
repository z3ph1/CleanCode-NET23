namespace xUnitDemo;

public class Rectangle(ICalculator calculator)
{
    private readonly ICalculator _calculator = calculator;

    public decimal SideA { get; set; }
    public decimal SideB { get; set; }

    public decimal Circumference()
    {
        var sumOfAs = _calculator.Multiply(SideA, 2);
        var sumOfBs = _calculator.Multiply(SideB, 2);

        var circumference = _calculator.Add(sumOfAs, sumOfBs);

        return circumference;
    }
}