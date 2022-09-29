namespace AsyncAwait;

public static class RandomCount
{

    public static async Task Main(string[] args)
    {
        
    }

    public static async Task<int> GetNumber(int number)
    {
        Random random = new Random(); 
        await Task.Delay(random.Next(0,1000));
        return number;
    }
}