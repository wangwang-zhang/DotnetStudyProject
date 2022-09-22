
namespace FizzBuzzTest;

public class FizzBuzzWhizzTest
{
    [Fact]
    public void Should_Return_Correct_String_When_Include_3_5_7_Or_Not()
    {
        int stuId1 = 13;
        int stuId2 = 15;
        int stuId3 = 17;
        int stuId4 = 135;
        int stuId5 = 137;
        int stuId6 = 157;
        int stuId7 = 357;
        int stuId8 = 121;
        
        Student stu = new Student();
        
        Assert.Equal( "Fizz",stu.IncludeNum(stuId1));
        Assert.Equal( "Buzz",stu.IncludeNum(stuId2));
        Assert.Equal( "Whizz",stu.IncludeNum(stuId3));
        Assert.Equal( "FizzBuzz",stu.IncludeNum(stuId4));
        Assert.Equal( "FizzWhizz",stu.IncludeNum(stuId5));
        Assert.Equal( "BuzzWhizz",stu.IncludeNum(stuId6));
        Assert.Equal( "FizzBuzzWhizz",stu.IncludeNum(stuId7));
        Assert.Equal( "121",stu.IncludeNum(stuId8));
    }
    
    
}