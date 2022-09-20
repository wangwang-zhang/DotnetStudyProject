using System.Text;

namespace FizzBuzz;

internal class Student
{
    private readonly int _studentId;
    public Student(int studentId)
    {
        _studentId = studentId;
    }

    public void SayNumber()
    {
        var num = _studentId;

        if (num % 3 == 0 && num % 5 == 0 && num % 7 == 0)
        {
            Console.WriteLine("{0, 3}:  {1}", num, FizzBuzz.FizzBuzzWhizz);
        }
        else if (num % 3 == 0 && num % 5 == 0)
        {
            Console.WriteLine("{0, 3}:  {1}", num, FizzBuzz.FizzBuzz);
        }
        else if (num % 3 == 0 && num % 7 == 0)
        {
            Console.WriteLine("{0, 3}:  {1}", num, FizzBuzz.FizzWhizz);
        }
        else if (num % 5 == 0 && num % 7 == 0)
        {
            Console.WriteLine("{0, 3}:  {1}", num, FizzBuzz.BuzzWhizz);
        }
        else if (num % 3 == 0)
        {
            Console.WriteLine("{0, 3}:  {1}", num, FizzBuzz.Fizz);
        }
        else if (num % 5 == 0)
        {
            Console.WriteLine("{0, 3}:  {1}", num, FizzBuzz.Buzz);
        }
        else if (num % 7 == 0)
        {
            Console.WriteLine("{0, 3}:  {1}", num, FizzBuzz.Whizz);
        }
        else
        {
            IncludeNum(num);
        }
    }

    private void IncludeNum(int num)
    {
        int hundredsDigit = num / 100;
        int tensDigit = num % 100 / 10;
        int unitsDigit = num % 10;
        StringBuilder str = new StringBuilder();
        if (hundredsDigit == 3 || tensDigit == 3 || unitsDigit == 3)
            str.Append(FizzBuzz.Fizz);
        if (hundredsDigit == 5 || tensDigit == 5 || unitsDigit == 5)
            str.Append(FizzBuzz.Buzz);
        if (hundredsDigit == 7 || tensDigit == 7 || unitsDigit == 7)
            str.Append(FizzBuzz.Whizz);
        if (str.Length == 0)
            str.Append(num);
        Console.WriteLine("{0, 3}:  {1}", num, str.ToString());
    }

    private enum FizzBuzz
    {
        FizzBuzzWhizz,
        FizzBuzz,
        FizzWhizz,
        BuzzWhizz,
        Fizz,
        Buzz,
        Whizz
    };
}