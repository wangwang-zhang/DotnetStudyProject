using AsyncAwait;
using static AsyncAwait.RandomCount;

namespace AsyncAwaitTest;

public class AsyncAwaitTest
{

    [Fact]
    public async Task Should_Return_Correct_Task_Int()
    {
        const int testNumber = 10;
        var resultNumber = await GetNumber(testNumber);
        Assert.Equal(10, resultNumber);
    }

    [Fact]
    public async Task Should_Return_Correct_Value()
    {
        const int testNumber = 10;
        await PrintNumber(testNumber);
        Assert.Equal(10, _count);
    }
}