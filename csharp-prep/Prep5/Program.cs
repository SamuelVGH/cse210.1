using System;

class Program
{
    static void Main(string[] args)
    {
        MainCalled();

        string userName = AskUserName();

        int favNumber = AskFavoriteNumber();

        int favNumberSquared = SquareNumber(favNumber);

        Result(userName, favNumberSquared);
    }

    static void MainCalled()
    {
        Console.WriteLine("hello everyone");
    }

    static string AskUserName()
    {
        Console.WriteLine("What is your name? ");
        string userName = Console.ReadLine();
        Console.WriteLine($"Welcome, {userName}");
        return userName;
    }

    static int AskFavoriteNumber()
    {
        Console.Write("What is your favorite number? ");
        int favNumberAsInt = int.Parse(Console.ReadLine());
        Console.WriteLine($"{favNumberAsInt} is a great number!");
        return favNumberAsInt;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void Result(string userName, int square)
    {
        Console.WriteLine($"{userName}, the square of your favorite number is {square}");
    }
}