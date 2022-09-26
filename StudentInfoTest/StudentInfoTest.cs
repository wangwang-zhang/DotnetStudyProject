namespace StudentInfoTest;

public class StudentInfoTest
{
    [Fact]
    public void Should_Be_Able_To_Add_StudentInfo_To_List()
    {
        StudentInfo studentInfo = new StudentInfo();
        List<StudentInfo> stuLists = new List<StudentInfo>();
        
        stuLists.Add(studentInfo);
        
        Assert.Equal(studentInfo, stuLists[0]);

    }

    [Fact]
    public void Should_Be_Able_To_Delete_StudentInfo_In_Lists()
    {
        StudentInfo studentInfo = new StudentInfo();
        List<StudentInfo> studentLists = new List<StudentInfo>();
        studentLists.Add(studentInfo);
        bool res = studentLists.Remove(studentInfo);
        
        Assert.True(res);
        Assert.Empty(studentLists);
    }

    [Fact]
    public void Should_Be_Able_To_Update_List_Of_StudentInfo()
    {
        List<StudentInfo> stuLists = new List<StudentInfo>();
        StudentInfo studentInfoOne = new StudentInfo(1, "Tom", 1, "Male", 15);
        StudentInfo studentInfoTwo = new StudentInfo(2, "Lucas", 2, "Female", 16);
        stuLists.Add(studentInfoOne);
        stuLists.Add(studentInfoTwo);

        stuLists[0].StudentName = "Amy";
        StudentInfo expectedStuInfo = new StudentInfo(1, "Amy", 1, "Male", 15);
       
        Assert.Equal("Amy",stuLists[0].StudentName);
    }
    [Fact]
    public void Should_Be_Able_To_Query_StudentInfo_In_List()
    {
        List<StudentInfo> studentLists = new List<StudentInfo>();
        StudentInfo studentInfoOne = new StudentInfo(1, "Tom", 1, "Male", 15);
        StudentInfo studentInfoTwo = new StudentInfo(2, "Lucas", 2, "Female", 16);
        StudentInfo studentInfoThree = new StudentInfo(3, "Dave", 2, "Female", 15);
        studentLists.Add(studentInfoOne);
        studentLists.Add(studentInfoTwo);
        studentLists.Add(studentInfoThree);

        List<StudentInfo> studentInfos = studentLists.FindAll(item =>  item.StudentClass == 2);

        Assert.Equal(2,studentInfos.Count);
    }

    [Fact]
    public void Should_Calculate_Student_Total_Score_By_Class_And_Put_Into_HashSet()
    {
        Dictionary<int, Score> stuDictionaries = new Dictionary<int, Score>();
        
        StudentInfo stuInfoOne = new StudentInfo(1, "Tom", 1, "Male", 15);
        StudentInfo stuInfoTwo = new StudentInfo(2, "Lucas", 2, "Female", 16);
        StudentInfo stuInfoThree = new StudentInfo(3, "Dave", 2, "Female", 15);
        
        Score scoreOne = new Score(1, 50, 60, 70);
        Score scoreTwo = new Score(2, 55, 65, 80);
        Score scoreThree = new Score(3, 56, 50, 90);
        
        List<StudentInfo> studentInfos = new List<StudentInfo>();
        studentInfos.Add(stuInfoOne);
        studentInfos.Add(stuInfoTwo);
        studentInfos.Add(stuInfoThree);
        
        stuDictionaries.Add(stuInfoOne.StudentId,scoreOne);
        stuDictionaries.Add(scoreTwo.StudentId,scoreTwo);
        stuDictionaries.Add(scoreThree.StudentId,scoreThree);

        HashSet<double> classOne = new HashSet<double>();
        if (classOne == null) throw new ArgumentNullException(nameof(classOne));
        HashSet<double> classTwo = new HashSet<double>();

        foreach (var item in stuDictionaries)
        {
            StudentInfo? studentInfo = studentInfos.Find(stu => stu.StudentId == item.Key);
            if (studentInfo != null)
                switch (studentInfo.StudentClass)
                {
                    case 1:
                        classOne.Add(item.Value.English + item.Value.Math + item.Value.Physics);
                        break;
                    case 2:
                        classTwo.Add(item.Value.English + item.Value.Math + item.Value.Physics);
                        break;
                }
        }
        
        Assert.Single(classOne);
        Assert.Equal(2, classTwo.Count);
        Assert.Equal(classOne,new HashSet<double>(){ 180 });
        Assert.Equal(classTwo,new HashSet<double>(){ 200, 196 });
        
    }
}