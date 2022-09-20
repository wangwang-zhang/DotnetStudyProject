namespace FizzBuzz;

public static class Program
{
    private static void Main(string[] args)
    {
        var students = StudentGenerator.Generator(120);
        for (var i = 0; i < 120; ++i)
        {
            students[i].SayNumber();
        }
    }
}