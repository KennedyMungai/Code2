using static System.Console;

namespace Code2.Chapter01.TopLevelProgram;

public class Program
{
    public static void Main(string[] args)
    {
        WriteLine("Hello from a top level program");
        WriteLine(Environment.OSVersion.VersionString);
    }
}