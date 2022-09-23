namespace ExtendsFunTest;

public class ExtendsTest
{
    [Fact]
    public void Should_Remove_Duplicate_String_In_List()
    {
        List<string> listStr = new List<string>()
        {
            "hello",
            "world",
            "hello",
            "world"
        };
        var resultListStr = listStr.RemoveDuplication();
        Assert.Equal("hello world", string.Join(" ",resultListStr.ToArray()));
    }

    [Fact]
    public void Should_Remove_Duplicate_IntValue_In_List()
    {
        List<int> listStr = new List<int>() { 1, 2, 2, 3, 3, 4, 4, 5 };
        var resultListInt = listStr.RemoveDuplication();
        Assert.Equal("1 2 3 4 5", string.Join(" ",resultListInt.ToArray()));
    }
    
}