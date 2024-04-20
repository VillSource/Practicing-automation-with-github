using Villsource.Common;
using Villsource.Featurs.Calculators;

namespace Villsource
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string expression = @"11+2*50+(22+4)";
            ICalculator cal = new ExpressionCalculator(expression);
            _ = cal.Excecute();

        }
    }
}
