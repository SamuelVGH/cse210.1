using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    
    {
        Console.WriteLine("Hello Prep4 World!");
        List <int> numbers= new List<int> ();
        int number = -1;
        while (number != 0)
        {
            Console.WriteLine ("say a number (0 to quit)");
            string numberOfUser= Console.ReadLine();
            number= int.Parse(numberOfUser);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum= 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"the sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }   
}