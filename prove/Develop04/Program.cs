using System;
using System.Threading;
using System.Collections.Generic;

class Activity
{
    protected int duration;

    public Activity(int duration)
    {
        this.duration = duration;
    }

    public virtual void Start()
    {
        Console.WriteLine("Starting the activity...");
        Thread.Sleep(2000);
    }

    public virtual void End()
    {
        Console.WriteLine("You've done a good job!");
        Console.WriteLine($"Activity completed: {this.GetType().Name}");
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(2000);
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Breathing Activity:");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");
        Thread.Sleep(2000);

        for (int i = 0; i < duration; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");

            Thread.Sleep(1000);
        }

        base.End();
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Reflection Activity:");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Thread.Sleep(2000);

        string prompt = prompts[new Random().Next(prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000);
        }

        base.End();
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Listing Activity:");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Thread.Sleep(2000);

        string prompt = prompts[new Random().Next(prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);

        Console.WriteLine("Get ready to start listing...");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }

        Console.WriteLine("Enter an item (or type 'done' to finish): ");
        int itemsCount = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
                break;
            itemsCount++;
        }

        Console.WriteLine($"Number of items listed: {itemsCount}");
        base.End();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        string choice = Console.ReadLine();
        int duration;

        try
        {
            Console.WriteLine("Enter the duration of the activity (in seconds): ");
            duration = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Exiting...");
            return;
        }

        Activity activity;
        switch (choice)
        {
            case "1":
                activity = new BreathingActivity(duration);
                break;
            case "2":
                activity = new ReflectionActivity(duration);
                break;
            case "3":
                activity = new ListingActivity(duration);
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting...");
                return;
        }

        activity.Start();
    }
}
