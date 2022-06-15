using static System.Console;

namespace Code2.Chapter03.Operators;

public class Program
{
    public static void Main(string[] args)
    {
        int a = 3;
        int b = a++;

        WriteLine($"a is {a} and b is {b}");
    }
}