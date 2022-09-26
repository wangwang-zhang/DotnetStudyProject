namespace StudentInfoTest;

public class StudentInfoTest
{
    [Fact]
    public void Should_Be_Able_To_Add_StudentInfo_To_List()
    {
        StudentInfo StudentInfo = new StudentInfo();
        List<StudentInfo> stuLists = new List<StudentInfo>();
        
        stuLists.Add(StudentInfo);
        
        Assert.Equal(stuLists[0], StudentInfo);

    }

    [Fact]
    public void Should_Be_Able_To_Delete_StudentInfo_In_Lists()
    {
        StudentInfo studentInfo = new StudentInfo();
        List<StudentInfo> stuLists = new List<StudentInfo>();
        stuLists.Add(studentInfo);
        bool res = stuLists.Remove(studentInfo);
        
        Assert.True(res);
        Assert.Empty(stuLists);
    }
}