using System.ComponentModel;
using static System.Console;

namespace Code2.Chapter02.Formatting;

public class Program
{
    public static void Main(string[] args)
    {
        int numberOfApples = 12;
        decimal pricePerApple = 0.35M;

        WriteLine(
            format:"{0} apples cost {1:C}",
            arg0: numberOfApples ,
            arg1: pricePerApple * numberOfApples
        );

        string formatted = string.Format(
            format: "{0} apples cost {1:C}",
            arg0: numberOfApples,
            arg1: pricePerApple * numberOfApples
        );
    }
}