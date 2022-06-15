using static System.Console;

namespace Code2.Chapter04.Debugging;

public class Program
{
    public static void Main(string[] args)
    {
        double a = 4.5;
        double b = 2.5;
        double answer = Add(a, b);
        WriteLine($"{a} + {b} = {answer}");
    }

    static double Add(double a, double b)
    {
        return a* b;
    }
}