using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_title} by {base.GetSummary()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Testing the classes
        // Creating a MathAssignment object
        MathAssignment mathHW = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathHW.GetSummary());
        Console.WriteLine(mathHW.GetHomeworkList());

        // Creating a WritingAssignment object
        WritingAssignment writingHW = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingHW.GetSummary());
        Console.WriteLine(writingHW.GetWritingInformation());
    }
}
