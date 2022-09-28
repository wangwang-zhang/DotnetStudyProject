using System.Collections;
using System.Collections.ObjectModel;
using LINQ;
using Xunit.Abstractions;

namespace LINQTest;

public class LinqTest
{
    readonly Collection<Student> _studentLists = new Collection<Student>()
    {
        new Student() { StudentID = 1, StudentName = "Amy", Age = 15, CourseID = 1 },
        new Student() { StudentID = 2, StudentName = "Bob", Age = 16, CourseID = 1 },
        new Student() { StudentID = 3, StudentName = "Cindy", Age = 15, CourseID = 2 },
        new Student() { StudentID = 4, StudentName = "Dave", Age = 16, CourseID = 2 },
        new Student() { StudentID = 5, StudentName = "Easton", Age = 16, CourseID = 3 },
    };

    private readonly Collection<Course> _courseLists = new Collection<Course>()
    {
        new Course() { CourseID = 1, CourseName = "Math" },
        new Course() { CourseID = 2, CourseName = "Biology" },
        new Course() { CourseID = 3, CourseName = "English" }
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

    [Fact]
    public void Should_Join_StudentLists_And_CourseLists_By_CourseID()
    {
        var joinResults = from student in _studentLists
            join course in _courseLists
                on student.CourseID equals course.CourseID
            select new
            {
                student.StudentName,
                courseName = course.CourseName
            };
        
        Assert.Equal( "Amy", joinResults.ToArray()[0].StudentName);
        Assert.Equal( "Math", joinResults.ToArray()[0].courseName);
        Assert.Equal( "Bob", joinResults.ToArray()[1].StudentName);
        Assert.Equal( "Math", joinResults.ToArray()[1].courseName);
        Assert.Equal( "Cindy", joinResults.ToArray()[2].StudentName);
        Assert.Equal( "Biology", joinResults.ToArray()[2].courseName);
        Assert.Equal( "Dave", joinResults.ToArray()[3].StudentName);
        Assert.Equal( "Biology", joinResults.ToArray()[3].courseName);
        Assert.Equal( "Easton", joinResults.ToArray()[4].StudentName);
        Assert.Equal( "English", joinResults.ToArray()[4].courseName);

    }

    private readonly ITestOutputHelper output;
    public LinqTest(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Fact]
    public void Should_Join_StudentLists_And_CourseLists_GroupBy_CourseID()
    {
        var groupJoinResults = _courseLists.GroupJoin(_studentLists,
            course => course.CourseID,
            student => student.CourseID,
            (course, studentsGroup) => new
            {
                Students = studentsGroup,
                courseName = course.CourseName
            }
        );

        Assert.Equal("Math", groupJoinResults.ToArray()[0].courseName);
        Assert.Equal(2, groupJoinResults.ToArray()[0].Students.Count());
        Assert.Equal("Amy", groupJoinResults.ToArray()[0].Students.ToArray()[0].StudentName);
    }

    [Fact]
    public void Should_Return_Student_Whose_Name_Is_Longest()
    {
        var studentWithLongestName = from outerStudent in _studentLists
            where outerStudent.StudentName.Length == _studentLists.Max(innerStudent => innerStudent.StudentName.Length)
            select $"{outerStudent.StudentName}";
          
        Assert.Equal("Easton", studentWithLongestName.ToArray()[0].ToString());
    }

    [Fact]
    public void Should_Return_Correct_Count_Of_Students_Whose_Age_Is_Bigger_Than_15()
    {
        int studentCount = _studentLists.Count(student => student.Age > 15);
        Assert.Equal(3, studentCount);
    }

    [Fact]
    public void Should_Return_Distinct_StudentLists()
    { 
        IList<Student> studentLists = new List<Student>()
        {
            new Student() { StudentID = 1, StudentName = "Amy", Age = 15, CourseID = 1 },
            new Student() { StudentID = 2, StudentName = "Bob", Age = 16, CourseID = 1 },
            new Student() { StudentID = 3, StudentName = "Cindy", Age = 15, CourseID = 2 },
            new Student() { StudentID = 4, StudentName = "Dave", Age = 16, CourseID = 2 },
            new Student() { StudentID = 2, StudentName = "Bob", Age = 16, CourseID = 1 },
            new Student() { StudentID = 3, StudentName = "Cindy", Age = 15, CourseID = 2 },
        };
        var distinctStudents = studentLists.Distinct(new StudentComparer());
        
        Assert.Equal(4, distinctStudents.Count());
    }
}

public class StudentComparer : IEqualityComparer<Student>
{
    public bool Equals(Student studentFirst, Student studentSecond)
    {
        if (studentFirst.StudentID == studentSecond.StudentID 
            && studentFirst.StudentName.ToLower() == studentSecond.StudentName.ToLower() )
            return true;

        return false;
    }
    public int GetHashCode(Student obj)
    {
        return obj.StudentID.GetHashCode();
    }
}