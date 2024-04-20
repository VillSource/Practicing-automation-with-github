using Villsource.Common;
using Xunit;

namespace Villsource.Featurs.Calculators.Tests;

public class ExpressionCalculatorTests
{

    [Fact]
    public void ExcecuteTest()
    {
        string expression = @"1+2*3";
        var expectedResult = 7;

        ICalculator cal = new ExpressionCalculator(expression);
        var actualResult = cal.Excecute();

        Xunit.Assert.Equal(expectedResult, actualResult);
    }

}