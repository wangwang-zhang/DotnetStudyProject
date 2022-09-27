using LINQ;

namespace LINQTest;

public class LinqTest
{
    readonly IList<Student> _studentLists = new List<Student>()
    {
        new Student() { StudentID = 1, StudentName = "Amy", Age = 15, CourseID = 1 },
        new Student() { StudentID = 2, StudentName = "Bob", Age = 16, CourseID = 1 },
        new Student() { StudentID = 3, StudentName = "Cindy", Age = 15, CourseID = 2 },
        new Student() { StudentID = 4, StudentName = "Dave", Age = 16, CourseID = 2 },
        new Student() { StudentID = 5, StudentName = "Easton", Age = 16, CourseID = 3 },
    };
    
    [Fact]
    public void Should_Return_Correct_Results_Group_By_Age()
    {
        var groupedResult = from student in _studentLists 
            group student by student.CourseID;

        IEnumerable<IGrouping<int,Student>> groupedResultLists = groupedResult.ToList();
        
        Assert.Equal(3, groupedResultLists.Count());
        Assert.Equal(1, groupedResultLists.ToArray()[0].Key);
        Assert.Equal(2, groupedResultLists.ToArray()[1].Key);
        Assert.Equal(3, groupedResultLists.ToArray()[2].Key);
    }

    [Fact]
    public void Should_Return_Correct_Results_Ordered_By_Age_From_Small_To_Big()
    {
        var orderedResults = from student in _studentLists
            orderby student.Age, student.StudentName
            select student.StudentName;
        
        var expectedStudentNameArray = new string[] { "Amy", "Cindy", "Bob", "Dave", "Easton" };
        Assert.Equal(expectedStudentNameArray, orderedResults.ToArray());
    }

    [Fact] 
    public void Should_Return_Correct_Results_Ordered_By_Age_From_Big_To_Small()
    {
        var orderedResults = from student in _studentLists
            orderby student.Age descending , student.StudentName
            select student.StudentName;
        
        var expectedStudentNameArray = new string[] { "Bob", "Dave", "Easton", "Amy", "Cindy" };
        Assert.Equal(expectedStudentNameArray, orderedResults.ToArray());
    }

    [Fact]
    public void Should_Return_Students_Whose_Age_Is_15()
    {
        var students = from student in _studentLists
            where student.Age == 15
            select student.StudentName;
        
        var expectedStudentNameArray = new string[] { "Amy", "Cindy" };
        Assert.Equal(expectedStudentNameArray, students.ToArray());
    }
}