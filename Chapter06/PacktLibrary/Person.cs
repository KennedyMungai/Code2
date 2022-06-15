using System.Security.Cryptography;
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

    
    public static Person Procreate(Person p1, Person p2)
    {
        Person baby = new
        {
            Name=$"Baby of {p1.Name} and {p2.Name}"
        }

        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }


}
