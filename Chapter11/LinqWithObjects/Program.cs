using static System.Console;

namespace Code2.Chapter11.LinqWithObjects;

public class Program
{
    public static void Main(string[] args)
    {
        string[] names = new[]
        {
            "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed"
        };

        WriteLine("Deferred Execution");

        var query1 = names.Where(name => name.EndsWith("m"));

        foreach (var name in query1)
        {
            WriteLine(name);
        }
    }
}