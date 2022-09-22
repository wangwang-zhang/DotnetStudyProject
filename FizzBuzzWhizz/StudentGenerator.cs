namespace FizzBuzzWhizz;

internal static class StudentGenerator
{
    public static List<Student> Generator(int count)
    {
        List<Student> students = new List<Student>();
        for (int i = 1; i <= count; ++i)
        {
            students.Add(new Student(i));
        }
        return students;
    }
}