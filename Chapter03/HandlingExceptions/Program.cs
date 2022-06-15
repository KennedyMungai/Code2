using System.Linq.Expressions;
using static System.Console;

namespace Code2.Chapter03.HandlingExceptions;

public class Program
{
    public static void Main(string[] args)
    {
        WriteLine("Before parsing");
        Write("What is your age?");
        string? input = ReadLine();

        try
        {
            int age = int.Parse(input);
            WriteLine($"You are {age} years old");
        }
        catch(OverflowException)
        {
            WriteLine("The age you entered is in the valid format but the value is too big");
        }
        catch (FormatException)
        {
            WriteLine("The age you entered is not in the valid format");
        }
        catch (System.Exception ex)
        {
            WriteLine($"{ex.GetType()} says {ex.Message}");
        }
    }
}