using Xunit;

namespace FizzBuzzWhizz.test;

public class Test
{
    [Fact]
    public void Test1()
    {
        int stuId = 15;
        Student stu = new Student(stuId);
        string result = stu.IncludeNum(stuId);
        Assert.Equal( "Buzz",result);
    }
}