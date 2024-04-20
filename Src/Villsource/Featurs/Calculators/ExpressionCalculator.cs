using Villsource.Common;

namespace Villsource.Featurs.Calculators;

public class ExpressionCalculator : ICalculator
{
    private readonly string _expression;

    public ExpressionCalculator(string expression)
    {
        _expression = expression;
    }

    public double Excecute()
    {
        return Evaluate(_expression);
    }

    // Function to check if the character is an operator
    static bool IsOperator(char op)
    {
        return op == '+' || op == '-' || op == '*' || op == '/' || op == '^';
    }

    // Function to perform arithmetic operations
    static double ApplyOperation(double a, double b, char op)
    {
        switch (op)
        {
            case '+':
                return a + b;
            case '-':
                return b - a;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    throw new DivideByZeroException("Division by zero error!");
                }
                return a / b;
            case '^':
                return Math.Pow(a, b);
            default:
                throw new ArgumentException("Invalid operator!");
        }
    }

    // Function to evaluate infix expression
    public static double Evaluate(string expression)
    {
        Stack<double> values = new Stack<double>();
        Stack<char> operators = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];

            // Ignore whitespace characters
            if (c == ' ')
                continue;

            // If current character is a digit, get the whole number
            if (Char.IsDigit(c))
            {
                double num = 0;
                while (i < expression.Length && Char.IsDigit(expression[i]))
                {
                    num = num * 10 + (expression[i] - '0');
                    i++;
                }
                i--;
                values.Push(num);
            }

            // If current character is an opening bracket, push it to operators stack
            else if (c == '(')
            {
                operators.Push(c);
            }

            // If current character is a closing bracket, solve the expression till opening bracket
            else if (c == ')')
            {
                while (operators.Peek() != '(')
                {
                    values.Push(ApplyOperation(values.Pop(), values.Pop(), operators.Pop()));
                }
                operators.Pop(); // Remove the opening bracket
            }

            // If current character is an operator
            else if (IsOperator(c))
            {
                // While top of 'operators' has same or greater precedence to current
                // token, which is an operator. Apply operator on top of 'operators'
                // to top two elements in values stack
                while (operators.Count > 0 && Precedence(c) <= Precedence(operators.Peek()))
                {
                    values.Push(ApplyOperation(values.Pop(), values.Pop(), operators.Pop()));
                }

                // Push current character to 'operators'
                operators.Push(c);
            }
        }

        // Apply remaining operators on remaining values
        while (operators.Count > 0)
        {
            values.Push(ApplyOperation(values.Pop(), values.Pop(), operators.Pop()));
        }

        // Top of 'values' contains result
        return values.Pop();
    }

    // Function to get precedence of operators
    static int Precedence(char op)
    {
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            case '^':
                return 3;
            default:
                return -1;
        }
    }

}
