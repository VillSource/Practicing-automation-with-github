using Villsource.Common;

namespace Villsource.Featurs.Calculators;

public class AddCalculator : ICalculator
{
    private readonly double _a;
    private readonly double _b;
    public AddCalculator(double a, double b)
    {
        this._a = a;
        this._b = b;
    }

    public double Excecute()
    {
        return _a + _b;
    }
}
