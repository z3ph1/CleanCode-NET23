namespace xUnitDemo.Tests;

public class Calculator_Tests
{
    [Theory]
    [InlineData(1,2, 3)]
    [InlineData(2,2, 4)]
    [InlineData(20,2, 22)]
    [InlineData(2,20, 22)]
    [InlineData(20,20, 40)]
    [InlineData(2.9,2, 4.9)]
    [InlineData(2,5.7, 7.7)]
    [InlineData(2.9,5.7, 8.6)]
    [InlineData(-2.9,-5.7, -8.6)]
    public void Calculator_Add_Returns_Sum_Of_AAndB(decimal a, decimal b, decimal sum)
    {
        //Arrange
        var sut = new Calculator();
        //Act
        var result = sut.Add(a, b);
        //Assert
        Assert.Equal(sum, result);
    }

}