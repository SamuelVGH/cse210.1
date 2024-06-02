using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

[Serializable]
class Goal {
    public string Name { get; set; }
    public int Target { get; set; }
    public int Progress { get; set; }

    public Goal(string name, int target) {
        Name = name;
        Target = target;
        Progress = 0;
    }

    public void AddProgress(int points) {
        Progress += points;
    }

    public void ShowProgress() {
        Console.WriteLine($"Progress of goal '{Name}': {Progress}/{Target} points");
    }
}

class Program {
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args) {
        LoadGoals();
        
        ShowMenu();
    }

    static void ShowMenu() {
        while (true) {
            Console.WriteLine("1. Add new goal");
            Console.WriteLine("2. Track progress of a goal");
            Console.WriteLine("3. Show progress of a goal");
            Console.WriteLine("4. Save progress");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option) {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    TrackProgress();
                    break;
                case "3":
                    ShowProgress();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddGoal() {
        Console.Write("Enter the name of the new goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the target of the new goal: ");
        int target = int.Parse(Console.ReadLine());

        Goal newGoal = new Goal(name, target);
        goals.Add(newGoal);

        Console.WriteLine("New goal added successfully!");
    }

    static void TrackProgress() {
        Console.WriteLine("Available goals:");
        for (int i = 0; i < goals.Count; i++) {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        Console.Write("Select the goal you want to track progress for: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count) {
            Console.Write("Enter the amount of points to add: ");
            int points = int.Parse(Console.ReadLine());
            goals[index].AddProgress(points);
            Console.WriteLine("Progress updated successfully.");
        } else {
            Console.WriteLine("Invalid goal index.");
        }
    }

    static void ShowProgress() {
        Console.WriteLine("Available goals:");
        for (int i = 0; i < goals.Count; i++) {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        Console.Write("Select the goal you want to show progress for: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count) {
            goals[index].ShowProgress();
        } else {
            Console.WriteLine("Invalid goal index.");
        }
    }

    static void SaveGoals() {
        try {
            using (FileStream fs = new FileStream("goals.json", FileMode.Create)) {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Goal>));
                serializer.WriteObject(fs, goals);
                Console.WriteLine("Progress saved successfully.");
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error saving progress: {ex.Message}");
        }
    }

    static void LoadGoals() {
        try {
            if (File.Exists("goals.json")) {
                using (FileStream fs = new FileStream("goals.json", FileMode.Open)) {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Goal>));
                    goals = (List<Goal>)serializer.ReadObject(fs);
                    Console.WriteLine("Progress loaded successfully.");
                }
            } else {
                Console.WriteLine("No saved progress found.");
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error loading progress: {ex.Message}");
        }
    }
}
