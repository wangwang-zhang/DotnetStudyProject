namespace AsyncAwait;

public static class RandomCount
{
    public static int _count = 0;
    public static int _flag = 0;
    public static int _number = 0;
	
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Please input the number of count-off:");
        _number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("-------------------");
        
        var tasks = new List<Task>();
        
        for (var i = 1; i <= _number; i++)
        {
            tasks.Add(PrintNumber(i));
        }
        await Task.WhenAll(tasks);
    }

    public static async Task PrintNumber(int number)
    {
        int resultNumber = await GetNumber(number);
        _flag++;
       if (_count == 0)
       {
           Console.WriteLine("Lets start");
       }
       else
       {
           Console.WriteLine(_flag == _number ? "Report after {0} and I am the last" : "Report after {0}", _count);
       }
       _count = resultNumber;
    }
	
    public static async Task<int> GetNumber(int i)
    {
        Random random = new Random(); 
        await Task.Delay(random.Next(0,1000));
        return i;
    }
}