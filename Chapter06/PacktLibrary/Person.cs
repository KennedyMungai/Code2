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

    /// <summary>
    /// This is a method that enables Procreation
    /// </summary>
    /// <param name="p1">The first Person</param>
    /// <param name="p2">The second Person</param>
    /// <returns></returns>
    public static Person Procreate(Person p1, Person p2)
    {
        Person baby = new()
        {
            Name=$"Baby of {p1.Name} and {p2.Name}"
        };

        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }

    /// <summary>
    /// Makes it easy to call the Procreate method
    /// </summary>
    /// <param name="partner">This is the second Person involved</param>
    /// <returns></returns>
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }


    //delegate field
    public EventHandler? Shout;

    //Data field
    public int AngerLevel;

    //Method
    public void Poke()
    {
        AngerLevel++;

        if(AngerLevel >= 3)
        {
            //If something is listening...
            if(Shout != null)
            {
                //... then call the delegate
                Shout(this, EventArgs.Empty);
            }
        }
    }
}
