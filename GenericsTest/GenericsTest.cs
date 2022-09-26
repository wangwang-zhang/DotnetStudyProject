namespace GenericsTest;

public class GenericsTest
{
    [Fact]
    public void Should_Return_Corresponding_Type()
    {
        DataProcessor<string> processor = new DataProcessor<string>();

        string actualInt = processor.ValueType<int>(10);
        string actualString = processor.ValueType<string>("Hello");
        string actualDouble = processor.ValueType<double>(1.23);
        
        Assert.Equal("Int32", actualInt);
        Assert.Equal("String",actualString);
        Assert.Equal("Double", actualDouble);
    }

    [Fact]
    public void Should_Use_Correct_Type_Based_On_Generics_Constraint()
    {
        DataProcessor<string> processorString = new DataProcessor<string>();
        DataProcessor<Student> processorStudent = new DataProcessor<Student>();
        Student student = new Student("Tom", 1);
        processorString.Data = "Hello";
        processorStudent.Data = student;
        
        Assert.Equal("Hello",processorString.Data);
        Assert.Equal("Tom", processorStudent.Data.Name);
        Assert.Equal(1,processorStudent.Data.Id);
    }
}