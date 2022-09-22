
namespace FizzBuzzTest;

public class UnitTest1
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