

namespace ExtendsFun;

public static class Program
{
    static void Main(string[] args)
    {
        List<string> listStr = new List<string>
        {
            "hello",
            "world",
            "hello",
            "world"
        };

        List<int> listInt = new List<int> { 1, 2, 2, 3, 3, 4, 5 };
        
        
        var resultStr = listStr.RemoveDuplication();
        var resultInt = listInt.RemoveDuplication();
        
        Console.WriteLine(string.Join(" ",resultStr.ToArray()));
        Console.WriteLine(string.Join(" ",resultInt.ToArray()));
    }
}