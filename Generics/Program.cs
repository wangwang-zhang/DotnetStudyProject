
namespace Generics;

static class Generics
{
    static void Main(string[] args)
    {
        DataProcessor<string> dp = new DataProcessor<string>
        {
            Data = "Hello World"
        };

        Console.WriteLine(dp.Data);
        Console.WriteLine(dp.ValueType<int>(10));
    }
}