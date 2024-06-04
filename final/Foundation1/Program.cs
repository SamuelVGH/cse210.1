using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Duration { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment comment = new Comment(commenterName, text);
        Comments.Add(comment);
    }

    public int GetNumComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Brawl Stars Gameplay", "Player1", 120);
        video1.AddComment("JohnDoe78", "Great video! I learned a lot from it.");
        video1.AddComment("GarGirl21", "Nice gameplay, keep it up!");
        videos.Add(video1);

        Video video2 = new Video("Brawl Stars Tips and Tricks", "Player2", 180);
        video2.AddComment("ProGamer99", "Thanks for the tips, they really helped!");
        videos.Add(video2);

        Video video3 = new Video("Brawl Stars New Update Revieeew", "Player3", 150);
        video3.AddComment("CasualPlayer23", "I'm not sure about the new update, what do you guys think?");
        video3.AddComment("Elprimo2000", "This update is awesome, loving the new features!");
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Duration: " + video.Duration + " seconds");
            Console.WriteLine("Number of comments: " + video.GetNumComments());
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine("- By: " + comment.CommenterName);
                Console.WriteLine("  Comment: " + comment.Text);
            }
            Console.WriteLine();
        }
    }
}
