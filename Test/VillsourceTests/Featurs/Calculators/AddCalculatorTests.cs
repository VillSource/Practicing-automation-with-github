using Xunit;

namespace Villsource.Featurs.Calculators.Tests;

public class AddCalculatorTests
{
    [Fact]
    public void AddCalculatorTest()
    {
        double a = 159; 
        double b = 1;
        double expectedResult = 160;

        var calculator = new AddCalculator(a, b);
        var actualResult = calculator.Excecute();

        Xunit.Assert.Equal(expectedResult, actualResult);
    }
}