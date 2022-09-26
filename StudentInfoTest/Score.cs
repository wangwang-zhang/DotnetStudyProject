namespace StudentInfoTest;

public class Score
{
    public int StuId { get; set; }
    public int Math { get; set; }
    public int English { get; set; }
    public int Physics { get; set; }

    public Score(int stuId, int math, int english, int physics)
    {
        StuId = stuId;
        Math = math;
        English = english;
        Physics = physics;
    }
}