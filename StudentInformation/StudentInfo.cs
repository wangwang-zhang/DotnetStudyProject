namespace StudentInformation;

public class StudentInfo
{
    public StudentInfo(){}

    public StudentInfo(int studentId, string studentName, int studentClass, string studentGender, int studentAge)
    {
        StudentId = studentId;
        StudentName = studentName;
        StudentClass = studentClass;
        StudentGender = studentGender;
        StudentAge = studentAge;
    }

    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int StudentClass { get; set; }
    public string StudentGender { get; set; } 
    public int StudentAge { get; set; }
    
    
}