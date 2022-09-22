using System.Text;

namespace FizzBuzzTest;

internal class Student
{
    private readonly int _studentId;

    public Student(int studentId)
    {
        _studentId = studentId;
    }

    public Student()
    {
        
    }

    public string FizzBuzzJudge(int num)
    {
        if (num % 3 == 0 && num % 5 == 0 && num % 7 == 0)
        {
            return FizzBuzz.FizzBuzzWhizz.ToString();
        }
        else if (num % 3 == 0 && num % 5 == 0)
        {
            return FizzBuzz.FizzBuzz.ToString();
        }
        else if (num % 3 == 0 && num % 7 == 0)
        {
            return FizzBuzz.FizzWhizz.ToString();
        }
        else if (num % 5 == 0 && num % 7 == 0)
        {
            return FizzBuzz.BuzzWhizz.ToString();
        }
        else if (num % 3 == 0)
        {
            return FizzBuzz.Fizz.ToString();
        }
        else if (num % 5 == 0)
        {
            return FizzBuzz.Buzz.ToString();
        }
        else if (num % 7 == 0)
        {
            return FizzBuzz.Whizz.ToString();
        }
        else
        {
           return IncludeNum(num);
        }
        
    }

    public string IncludeNum(int num)
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
        return str.ToString();
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

    public void SayNumber()
    {
        Console.WriteLine("{0, 3}:  {1}", _studentId, FizzBuzzJudge(_studentId));
    }
}