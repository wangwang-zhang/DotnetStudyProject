using LINQ;

namespace LINQTest;

public class LinqTest
{
    [Fact]
    public void Should_Return_Correct_Results_Group_By_Age()
    {
        IList<Student> studentLists = new List<Student>()
        {
            new Student() { StudentID = 1, StudentName = "Amy", Age = 15, CourseID = 1 },
            new Student() { StudentID = 2, StudentName = "Bob", Age = 16, CourseID = 1 },
            new Student() { StudentID = 3, StudentName = "Cindy", Age = 15, CourseID = 2 },
            new Student() { StudentID = 4, StudentName = "Dave", Age = 16, CourseID = 2 },
            new Student() { StudentID = 5, StudentName = "Easton", Age = 16, CourseID = 3 },
        };
        var groupedResult = from student in studentLists 
            group student by student.CourseID;

        IEnumerable<IGrouping<int,Student>> groupedResultLists = groupedResult.ToList();
        
        Assert.Equal(3, groupedResultLists.Count());
        Assert.Equal(1, groupedResultLists.ToArray()[0].Key);
        Assert.Equal(2, groupedResultLists.ToArray()[1].Key);
        Assert.Equal(3, groupedResultLists.ToArray()[2].Key);
    }
}