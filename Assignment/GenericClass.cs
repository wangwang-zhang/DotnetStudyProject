namespace Assignment;

public class GenericClass<T> where  T : class
{
    public GenericClass(T t)
    {
        _T = t;
    }
    public T _T { get; set; }
    
    public TU Add<TU>(TU a, TU b) 
    {
        return a;
    }
}