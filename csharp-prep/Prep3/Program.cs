using System;

class Program
{
    static void Main(string[] args)
    {   
        string firstMessage = "welcome to this game user, we are gonna play so...";
        Console.WriteLine ($"{firstMessage}");
        Random randomGenerator = new Random();
        int numberRandom = randomGenerator.Next(1, 101);
        string position= "";
        int Guess= -1; ///i strugle a lot with this haha, i know now i can use a valor that is not common. but i can use null as well
        while (Guess != numberRandom)
        {
            Console.WriteLine("say a guess");
            string numberGuess = Console.ReadLine ();
            Guess= int.Parse(numberGuess);
            if (Guess > numberRandom)
            {
                position= "your number need to be lower";
            }
            /*
            i learned that i can used in this way to use null 
            else if (guess == null)
            {
                position= "please enter a valid number, null is not allowed";
            }
            */
            else if (Guess == numberRandom)
            {
                position= $"yeahhh!! you got it!! {numberRandom} is the right number";
            }
            else if (Guess < numberRandom)
            {
                position= "your number need to be higher";
            }
            else 
            {
                position= "this is not a allowed answer";
            }
            Console.WriteLine($"{position}");
        }
        
    }
}