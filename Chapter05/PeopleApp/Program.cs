using System.Reflection.Metadata;
using Packt.Shared;

using static System.Console;

namespace Code2.Chapter05.PeopleApp;

public class Program
{
    public static void Main(string[] args)
    {
        Person bob = new();
        // WriteLine(bob.ToString());
        
        bob.Name = "Bob Smith";
        bob.DateOfBirth = new DateTime(1965, 12, 22);

        WriteLine($"{bob.Name} was born in {bob.DateOfBirth.ToLongDateString()}");
    }
}