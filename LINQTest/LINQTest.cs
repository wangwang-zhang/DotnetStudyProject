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
        var groupedResultLinq = _studentLists.GroupBy(student => student.CourseID);

        IEnumerable<IGrouping<int,Student>> groupedResultLists = groupedResult.ToList();
        IEnumerable<IGrouping<int,Student>> groupedResultListsLinq = groupedResultLinq.ToList();
        
        Assert.Equal(3, groupedResultLists.Count());
        Assert.Equal(1, groupedResultLists.ToArray()[0].Key);
        Assert.Equal(2, groupedResultLists.ToArray()[1].Key);
        Assert.Equal(3, groupedResultLists.ToArray()[2].Key);
        Assert.Equal(3, groupedResultListsLinq.Count());
        Assert.Equal(1, groupedResultListsLinq.ToArray()[0].Key);
        Assert.Equal(2, groupedResultListsLinq.ToArray()[1].Key);
        Assert.Equal(3, groupedResultListsLinq.ToArray()[2].Key);
    }
    [Fact]
    public void Should_Return_Correct_Results_Ordered_By_Age_From_Small_To_Big()
    {
        var orderedResults = from student in _studentLists
            orderby student.Age, student.StudentName
            select student.StudentName;

        var orderedResultsLinq = _studentLists.OrderBy(student => student.Age)
            .ThenBy(student => student.StudentName).Select(student => student.StudentName);

        var expectedStudentNameArray = new string[] { "Amy", "Cindy", "Bob", "Dave", "Easton" };
        Assert.Equal(expectedStudentNameArray, orderedResults.ToArray());
        Assert.Equal(expectedStudentNameArray, orderedResultsLinq.ToArray());
    }

    [Fact] 
    public void Should_Return_Correct_Results_Ordered_By_Age_From_Big_To_Small()
    {
        var orderedResults = from student in _studentLists
            orderby student.Age descending , student.StudentName
            select student.StudentName;
        
        var orderedResultsLinq = _studentLists.OrderByDescending(student => student.Age)
            .ThenBy(student => student.StudentName).Select(student => student.StudentName);
        
        var expectedStudentNameArray = new string[] { "Bob", "Dave", "Easton", "Amy", "Cindy" };
        Assert.Equal(expectedStudentNameArray, orderedResults.ToArray());
        Assert.Equal(expectedStudentNameArray, orderedResultsLinq.ToArray());
    }

    [Fact]
    public void Should_Return_Students_Whose_Age_Is_15()
    {
        var students = from student in _studentLists
            where student.Age == 15
            select student.StudentName;
        var studentsLinq = _studentLists.Where(student => student.Age == 15).Select(student => student.StudentName);

        var expectedStudentNameArray = new string[] { "Amy", "Cindy" };
        Assert.Equal(expectedStudentNameArray, students.ToArray());
        Assert.Equal(expectedStudentNameArray, studentsLinq.ToArray());
    }

    [Fact]
    public void Should_Join_StudentLists_And_CourseLists_By_CourseID()
    {
        var joinResults = from student in _studentLists
            join course in _courseLists
                on student.CourseID equals course.CourseID
            select new
            {
                studentName = student.StudentName,
                courseName = course.CourseName
            };
        var joinResultsLinq = _studentLists.Join(
            _courseLists,
            student => student.CourseID,
            course => course.CourseID,
            (student, course) => new
            {
                studentName = student.StudentName,
                courseName = course.CourseName
            });

        Assert.Equal( "Amy", joinResults.ToArray()[0].studentName);
        Assert.Equal( "Math", joinResults.ToArray()[0].courseName);
        Assert.Equal( "Bob", joinResults.ToArray()[1].studentName);
        Assert.Equal( "Math", joinResults.ToArray()[1].courseName);
        Assert.Equal( "Cindy", joinResults.ToArray()[2].studentName);
        Assert.Equal( "Biology", joinResults.ToArray()[2].courseName);
        Assert.Equal( "Dave", joinResults.ToArray()[3].studentName);
        Assert.Equal( "Biology", joinResults.ToArray()[3].courseName);
        Assert.Equal( "Easton", joinResults.ToArray()[4].studentName);
        Assert.Equal( "English", joinResults.ToArray()[4].courseName);
        
        Assert.Equal( "Amy", joinResultsLinq.ToArray()[0].studentName);
        Assert.Equal( "Math", joinResultsLinq.ToArray()[0].courseName);
        Assert.Equal( "Bob", joinResultsLinq.ToArray()[1].studentName);
        Assert.Equal( "Math", joinResultsLinq.ToArray()[1].courseName);
        Assert.Equal( "Cindy", joinResultsLinq.ToArray()[2].studentName);
        Assert.Equal( "Biology", joinResultsLinq.ToArray()[2].courseName);
        Assert.Equal( "Dave", joinResultsLinq.ToArray()[3].studentName);
        Assert.Equal( "Biology", joinResultsLinq.ToArray()[3].courseName);
        Assert.Equal( "Easton", joinResultsLinq.ToArray()[4].studentName);
        Assert.Equal( "English", joinResultsLinq.ToArray()[4].courseName);

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

        var groupJoinResultsLinQ = from course in _courseLists
            join student in _studentLists
                on course.CourseID equals student.CourseID
                into studentsGroup
            select new
            {
                Students = studentsGroup,
                courseName = course.CourseName
            };

        Assert.Equal("Math", groupJoinResults.ToArray()[0].courseName);
        Assert.Equal(2, groupJoinResults.ToArray()[0].Students.Count());
        Assert.Equal("Amy", groupJoinResults.ToArray()[0].Students.ToArray()[0].StudentName);
        
        Assert.Equal("Math", groupJoinResultsLinQ.ToArray()[0].courseName);
        Assert.Equal(2, groupJoinResultsLinQ.ToArray()[0].Students.Count());
        Assert.Equal("Amy", groupJoinResultsLinQ.ToArray()[0].Students.ToArray()[0].StudentName);
    }

    [Fact]
    public void Should_Return_Student_Whose_Name_Is_Longest()
    {
        var studentWithLongestName = from outerStudent in _studentLists
            where outerStudent.StudentName.Length == _studentLists.Max(innerStudent => innerStudent.StudentName.Length)
            select $"{outerStudent.StudentName}";

        var studentWithLongestNameLinq = _studentLists
            .Where(student => student.StudentName.Length ==
                              _studentLists.Max(innerStudent => innerStudent.StudentName.Length))
            .Select(student => $"{student.StudentName}");
           
          
        Assert.Equal("Easton", studentWithLongestName.ToArray()[0].ToString());
        Assert.Equal("Easton", studentWithLongestNameLinq.ToArray()[0].ToString());
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

    [Fact]
    public void Should_Return_First_Course()
    {
        Course? firstCourse = _courseLists.FirstOrDefault();
        Assert.Equal("Math", firstCourse.CourseName);
        Assert.Equal(1, firstCourse.CourseID);
    }

    [Fact]
    public void Should_Return_True_When_ALL_Is_Between_14_and_17()
    {
       var expectedResult =  _studentLists.All(student => student.Age is > 14 and < 17);
       Assert.True(expectedResult);
    }

    [Fact]
    public void Should_Return_True_When_Any_Student_Age_Is_Equal_To_15()
    {
        var expectedResult =  _studentLists.Any(student => student.Age is 15);
        Assert.True(expectedResult);
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