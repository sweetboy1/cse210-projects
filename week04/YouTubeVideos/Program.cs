using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video { Title = "Learn C# Basics", Author = "TechSavvy", LengthInSeconds = 480 };
        video1.AddComment(new Comment("Alice", "This helped me a lot!"));
        video1.AddComment(new Comment("Bob", "Great explanation."));
        video1.AddComment(new Comment("Charlie", "Thanks for the video!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video { Title = "Object-Oriented Programming in C#", Author = "CodeMaster", LengthInSeconds = 900 };
        video2.AddComment(new Comment("Dana", "Very clear examples."));
        video2.AddComment(new Comment("Eli", "Could you cover interfaces next?"));
        video2.AddComment(new Comment("Frank", "Loved it."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video { Title = "Abstraction Explained", Author = "DevSimplify", LengthInSeconds = 600 };
        video3.AddComment(new Comment("Grace", "Makes sense now!"));
        video3.AddComment(new Comment("Hank", "More videos like this, please."));
        video3.AddComment(new Comment("Ivy", "Super helpful."));
        videos.Add(video3);

        // Display all videos
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
