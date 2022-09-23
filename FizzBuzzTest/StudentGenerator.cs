namespace FizzBuzzTest;

internal static class StudentGenerator
{
    public static List<Student> Generator(int count)
    {
        List<Student> studentsLists = new List<Student>();
        for (int i = 1; i <= count; ++i)
        {
            studentsLists.Add(new Student(i));
        }
        return studentsLists;
    }
}