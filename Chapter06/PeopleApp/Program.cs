using PacktLibrary;

using static System.Console;

namespace Code2.Chapter06.PeopleApp;

public class Program
{
    public static void Main(string[] args)
    {
        Person harry = new()
        {
            Name = "Harry"
        };

        Person mary = new()
        {
            Name = "Mary"
        };

        Person jill = new()
        {
            Name = "Jill"
        };

        //Call instance method
        Person baby1 = mary.ProcreateWith(harry);
        baby1.Name = "Gary";

        //Call static method
        Person baby2 = Person.Procreate(harry, jill);

        harry.Shout = Harry_Shout;
        harry.Poke();
        harry.Poke();
        harry.Poke();
        harry.Poke();
    }
}