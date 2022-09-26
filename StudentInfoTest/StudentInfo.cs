namespace StudentInfoTest;

public class StudentInfo
{
    public StudentInfo(){}

    public StudentInfo(int stuId, string stuName, int stuClass, string stuGender, int stuAge)
    {
        StuId = stuId;
        StuName = stuName;
        StuClass = stuClass;
        StuGender = stuGender;
        StuAge = stuAge;
    }

    public int StuId { get; set; }
    public string StuName { get; set; }
    public int StuClass { get; set; }
    public string StuGender { get; set; } 
    public int StuAge { get; set; }
    
    
}