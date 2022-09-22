namespace Assignment;

public static class Program
{
    private static void Main(string[] args)
    {
        Person person = new Person();
        
        GenericClass<Person> genericPerson = new GenericClass<Person>(person);

        GenericClass<string> genericString = new GenericClass<string>("Hello World");

        Console.WriteLine(genericPerson._T);
        Console.WriteLine(genericString._T);
    }
}