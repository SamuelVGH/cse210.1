using System;
using System.Collections.Generic;
using System.IO; //This namespace provides classes and functions to perform input/output operations on files and directories. :D 
using System.Linq; //Extension that allow queries and operations on collections  // https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq //

public class Word
{
    public string Text { get; }
    public bool Hidden { get; set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }
}

public class ScriptureReference
{
    public string Reference { get; }
    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

public class Scripture
{
    private readonly List<Word> _words;
    private readonly ScriptureReference _reference;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"Scripture: {_reference.Reference}");
        foreach (var word in _words)
        {
            Console.Write(word.Hidden ? " ____" : $" {word.Text}");
        }
        Console.WriteLine();
    }

    public bool HideRandomWord()
    {
        var visibleWords = _words.Where(word => !word.Hidden).ToList();
        if (visibleWords.Count == 0)
        {
            Console.WriteLine("All words hidden. Program ended.");
            return false;
        }

        var random = new Random();
        var index = random.Next(visibleWords.Count);
        visibleWords[index].Hidden = true;

        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    
        var scriptureLines = File.ReadAllLines("scriptures.txt");
        var scriptures = new List<Scripture>();

        foreach (var line in scriptureLines)
        {
            var parts = line.Split(new char[] { ' ' }, 2);
            var reference = parts[0];
            var text = parts[1];
            var scriptureRef = new ScriptureReference(reference);
            var scripture = new Scripture(scriptureRef, text);
            scriptures.Add(scripture);
        }

     
        var random = new Random();
        var randomIndex = random.Next(scriptures.Count);
        var selectedScripture = scriptures[randomIndex];
        selectedScripture.Display();


        while (true)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            var input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            Console.Clear();
            selectedScripture.HideRandomWord();
            selectedScripture.Display();
        }
    }
}
