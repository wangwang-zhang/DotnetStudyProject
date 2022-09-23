
namespace FizzBuzzTest;

public class FizzBuzzWhizzTest
{
    
    [Theory]
    [InlineData(new int[]{13, 15, 17, 135, 137, 157, 357, 121},
                new string[]{"Fizz", "Buzz", "Whizz", "FizzBuzz", "FizzWhizz", "BuzzWhizz", "FizzBuzzWhizz", "121"})]
    public void Should_Return_Correct_String_When_Include_3_5_7_Or_Not(int[] stuIds, string[] expectedStr)
    {

        Student stu = new Student();
        
        Assert.Equal( expectedStr[0],stu.IncludeNum(stuIds[0]));
        Assert.Equal( expectedStr[1],stu.IncludeNum(stuIds[1]));
        Assert.Equal( expectedStr[2],stu.IncludeNum(stuIds[2]));
        Assert.Equal( expectedStr[3],stu.IncludeNum(stuIds[3]));
        Assert.Equal( expectedStr[4],stu.IncludeNum(stuIds[4]));
        Assert.Equal( expectedStr[5],stu.IncludeNum(stuIds[5]));
        Assert.Equal( expectedStr[6],stu.IncludeNum(stuIds[6]));
        Assert.Equal( expectedStr[7],stu.IncludeNum(stuIds[7]));
    }

    [Theory]
    [InlineData(new int[]{3, 5, 7, 15, 21, 35, 105},
        new string[]{"Fizz", "Buzz", "Whizz", "FizzBuzz", "FizzWhizz", "BuzzWhizz", "FizzBuzzWhizz"})]
    public void Should_Return_Correct_String_When_Num_Is_Multiple_Of_3_5_7(int[] stuIds, string[] expectedStr)
    {
        Student stu = new Student();
        
        Assert.Equal(expectedStr[0],stu.FizzBuzzJudge(stuIds[0]));
        Assert.Equal(expectedStr[1],stu.FizzBuzzJudge(stuIds[1]));
        Assert.Equal(expectedStr[2],stu.FizzBuzzJudge(stuIds[2]));
        Assert.Equal(expectedStr[3],stu.FizzBuzzJudge(stuIds[3]));
        Assert.Equal(expectedStr[4],stu.FizzBuzzJudge(stuIds[4]));
        Assert.Equal(expectedStr[5],stu.FizzBuzzJudge(stuIds[5]));
        Assert.Equal(expectedStr[6],stu.FizzBuzzJudge(stuIds[6]));
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