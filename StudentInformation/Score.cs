namespace StudentInformation;

public class Score
{
    public int StudentId { get; set; }
    public int Math { get; set; }
    public int English { get; set; }
    public int Physics { get; set; }

    public Score(int studentId, int math, int english, int physics)
    {
        StudentId = studentId;
        Math = math;
        English = english;
        Physics = physics;
    }
}