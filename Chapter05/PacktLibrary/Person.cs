using static System.Console;

namespace Packt.Shared;

public class Person
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public WondersOfTheAncientWorld favouriteAncientWonder;

    public List<Person> Children = new List<Person>();

    static void Harry_Shout(object? sender, EventArgs e)
    {
        if (sender is null)
        {
            return;
        }

        Person p =(Person)sender;
        WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
    }   
}