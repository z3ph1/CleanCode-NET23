using FakeItEasy;

namespace xUnitDemo.Tests;

public class Rectangle_Tests
{
    [Fact]
    public void Rectangle_Circumference_Returns_SumOfAllSides()
    {
        //Arrange

        var sideA = 1; 
        var sideB = 2;
        var sumOfAs = 2;
        var sumOfBs = 4;

        var calculator = A.Fake<ICalculator>();

        A.CallTo(() => calculator.Multiply(sideA,2)).Returns(sumOfAs);
        A.CallTo(() => calculator.Multiply(sideB,2)).Returns(sumOfBs);
        A.CallTo(() => calculator.Add(sumOfAs,sumOfBs)).Returns(sumOfAs + sumOfBs);

        var sut = new Rectangle(calculator);
        sut.SideA = sideA;
        sut.SideB = sideB;

        //Act
        var result = sut.Circumference();

        //Assert
        Assert.Equal(6, result);
    }
}