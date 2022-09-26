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

    [Fact]
    public void Should_Be_Able_To_Update_List_Of_StudentInfo()
    {
        List<StudentInfo> stuLists = new List<StudentInfo>();
        StudentInfo stuInfoOne = new StudentInfo(1, "Tom", 1, "Male", 15);
        StudentInfo stuInfoTwo = new StudentInfo(2, "Lucas", 2, "Female", 16);
        stuLists.Add(stuInfoOne);
        stuLists.Add(stuInfoTwo);

        stuLists[0].StuName = "Amy";
        StudentInfo expectedStuInfo = new StudentInfo(1, "Amy", 1, "Male", 15);
       
        Assert.Equal("Amy",stuLists[0].StuName);
    }
    [Fact]
    public void Should_Be_Able_To_Query_StudentInfo_In_List()
    {
        List<StudentInfo> stuLists = new List<StudentInfo>();
        StudentInfo stuInfoOne = new StudentInfo(1, "Tom", 1, "Male", 15);
        StudentInfo stuInfoTwo = new StudentInfo(2, "Lucas", 2, "Female", 16);
        StudentInfo stuInfoThree = new StudentInfo(3, "Dave", 2, "Female", 15);
        stuLists.Add(stuInfoOne);
        stuLists.Add(stuInfoTwo);
        stuLists.Add(stuInfoThree);

        List<StudentInfo> studentInfos = stuLists.FindAll(item =>  item.StuClass == 2);

        Assert.Equal(2,studentInfos.Count);
    }
}