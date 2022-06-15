using static System.Console;

namespace PacktLibrary;

public class Person : Object
{
    //fields
    public string? Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new();

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on {DateOfBirth.ToLongDateString()}");
    }
}
