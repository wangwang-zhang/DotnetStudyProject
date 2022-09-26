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
}