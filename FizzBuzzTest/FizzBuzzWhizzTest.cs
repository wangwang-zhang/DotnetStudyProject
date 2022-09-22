
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

    [Fact]
    public void Should_Return_Correct_String_When_Num_Is_Multiple_Of_3_5_7()
    {
        int stuId1 = 3;
        int stuId2 = 5;
        int stuId3 = 7;
        int stuId4 = 15;
        int stuId5 = 21;
        int stuId6 = 35;
        int stuId7 = 105;

        Student stu = new Student();
        
        Assert.Equal( "Fizz",stu.FizzBuzzJudge(stuId1));
        Assert.Equal( "Buzz",stu.FizzBuzzJudge(stuId2));
        Assert.Equal( "Whizz",stu.FizzBuzzJudge(stuId3));
        Assert.Equal( "FizzBuzz",stu.FizzBuzzJudge(stuId4));
        Assert.Equal( "FizzWhizz",stu.FizzBuzzJudge(stuId5));
        Assert.Equal( "BuzzWhizz",stu.FizzBuzzJudge(stuId6));
        Assert.Equal( "FizzBuzzWhizz",stu.FizzBuzzJudge(stuId7));
    }

    [Fact]
    public void Should_Generator_Students_List_Of_Correct_Length()
    {
        int stuCount = 10;
        var students = StudentGenerator.Generator(stuCount);
        Assert.Equal(stuCount, students.Count);
        Assert.IsType<List<Student>>(students);
    }
    
    
}