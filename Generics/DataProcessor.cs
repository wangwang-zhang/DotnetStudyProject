namespace Generics;

public class DataProcessor<T> where T : class
{
    public T Data { get; set; }
    
    public string ValueType<TU>(TU value)
    {
        return value.GetType().Name;
    }
}