using System;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("please enter your score: ");
        string score = Console.ReadLine ();

        int x = int.Parse(score);
        string letter = "";
        if (x >= 90 )
        {
            letter = "A";
        }
        else if (x >= 80)
        {
            letter = "B";
        }
        else if (x >= 70)
        {
            letter = "C";
        }
        else if (x >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }
        Console.WriteLine($"your score gave you a grade of: {letter}");

        if (x >= 70)
        {
            Console.WriteLine("you passed!");
        }
        else 
        {
            Console.WriteLine("sorry but you can try it again next semester!");
        }
    }
}