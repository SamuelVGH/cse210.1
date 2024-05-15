using System;
using System.Collections.Generic;
using System.IO;

class WriteHowWasYourDay { 
    public string Prompt;
    public string Response;
    public string Date;

    public WriteHowWasYourDay(string prompt, string response, string date) {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString() {
        return $"{Date}: {Prompt}\nResponse: {Response}\n";
    }
}

class ShowMeWhatIWrite { 
    private List<WriteHowWasYourDay> entries;

    public ShowMeWhatIWrite() {
        entries = new List<WriteHowWasYourDay>();
    }

    public void AddEntry(WriteHowWasYourDay entry) {
        entries.Add(entry);
    }

    public void DisplayEntries() {
        foreach (WriteHowWasYourDay entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (WriteHowWasYourDay entry in entries) {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string filename) {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split('|');
                if (parts.Length == 3) {
                    WriteHowWasYourDay entry = new WriteHowWasYourDay(parts[1], parts[2], parts[0]);
                    entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded from file.");
    }
}

class Program {
    static void Main(string[] args) {
        ShowMeWhatIWrite journal = new ShowMeWhatIWrite(); 
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What emotions were most prevalent today, and why do you think they surfaced?",
            "Can you identify any patterns or recurring themes in your recent experiences or thoughts?",
            "How do you feel your actions aligned with your values and goals today?",
            "Were there any moments today that challenged your beliefs or perspectives?",
            "What are you grateful for today, and why?",
            "Did any interactions today leave a significant impact on you, either positively or negatively?",
            "How did you cope with any challenges or obstacles that arose today?",
            "Reflect on a decision you made today. How do you feel about it now, and would you approach it differently in hindsight?",
            "Describe a moment of personal growth or self-discovery you experienced today.",
            "What activities or habits brought you the most joy or fulfillment today, and how can you incorporate more of them into your life?"
        };

        Random rand = new Random();

        while (true) {
            Console.WriteLine("1. Show an question / Write an asnwer");
            Console.WriteLine("2. Display it");
            Console.WriteLine("3. Save your notes to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    string prompt = prompts[rand.Next(prompts.Length)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new WriteHowWasYourDay(prompt, response, DateTime.Now.ToString()));
                    break;
                case "2":
                    Console.WriteLine("Journal Entries:");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
