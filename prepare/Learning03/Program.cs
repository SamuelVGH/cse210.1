using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        Fraction fNumber1 = new Fraction();
        Console.WriteLine(fNumber1.GetFractionString());
        Console.WriteLine(fNumber1.GetFractionInDecimal());


        Fraction fNumber2 = new Fraction(5);
        Console.WriteLine(fNumber2.GetFractionString());
        Console.WriteLine(fNumber2.GetFractionInDecimal());


        Fraction fNumber3 = new Fraction(3,4);
        Console.WriteLine(fNumber3.GetFractionString());
        Console.WriteLine(fNumber3.GetFractionInDecimal());

        Fraction fNumber4 = new Fraction(1,3);
        Console.WriteLine(fNumber4.GetFractionString());
        Console.WriteLine(fNumber4.GetFractionInDecimal());

    }
}