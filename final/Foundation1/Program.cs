using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; } = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(string commenterName, string text)
    {
        Comments.Add(new Comment(commenterName, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

public class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Program
{
    static void Main()
    {
        var videos = new List<Video>
        {
            new Video("The Rise of C#", "Programming Channel", 3600),
            new Video("Understanding Async/Await", "Tech Talks", 1800),
            new Video("LINQ Tutorial", "Code School", 2700)
        };

        // Adding comments to the first video
        videos[0].AddComment("John Doe", "Very insightful!");
        videos[0].AddComment("Jane Smith", "Can't wait for more!");

        // Adding comments to the second video
        videos[1].AddComment("Samuel Jackson", "This made async so simple, thanks!");
        videos[1].AddComment("Amanda Waller", "Brilliant explanation.");

        // Adding comments to the third video
        videos[2].AddComment("Bruce Wayne", "LINQ is powerful indeed.");
        videos[2].AddComment("Clark Kent", "Helpful tutorial on LINQ.");

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 30));
        }
    }
}
