
namespace FizzBuzzWhizz;

static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please input the number of students by ENTER:");
        int stuNum = Convert.ToInt32(Console.ReadLine());
        var students = StudentGenerator.Generator(stuNum);
        foreach (var student in students)
        {
            student.SayNumber();
        }
    }
}