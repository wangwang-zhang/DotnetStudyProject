namespace GenericsTest;

public class GenericsTest
{
    [Fact]
    public void Should_Return_Corresponding_Type()
    {
        DataProcessor<string> processor = new DataProcessor<string>();

        string actualInt = processor.ValueType<int>(10);
        string actualStr = processor.ValueType<string>("Hello");
        string actualFloat = processor.ValueType<double>(1.23);
        
        Assert.Equal("Int32", actualInt);
        Assert.Equal("String",actualStr);
        Assert.Equal("Double", actualFloat);
    }

    [Fact]
    public void Should_Use_Correct_Type_Based_On_Generics_Constraint()
    {
        DataProcessor<string> processorStr = new DataProcessor<string>();
        DataProcessor<Student> processorStu = new DataProcessor<Student>();
        Student stu = new Student("Tom", 1);
        processorStr.Data = "Hello";
        processorStu.Data = stu;
        
        Assert.Equal("Hello",processorStr.Data);
        Assert.Equal("Tom", processorStu.Data.Name);
        Assert.Equal(1,processorStu.Data.Id);
    }
}