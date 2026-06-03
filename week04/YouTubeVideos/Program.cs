using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the YouTubeVideos Project.");

            List<Video> videos = new List<Video>();
            // --- Video 1 ---- //
            Video video1 = new Video("C# Abstraction Tutorial for beginners", "CodeCraft", 620);

            video1.AddComment(new Comment("Molly", "This explained abstraction perfectly! Thanks."));
            video1.AddComment(new Comment("Bobby", "Great speed, looking forward to the next video."));
            video1.AddComment(new Comment("Melissa", "Can you show an example using interfaces next time?"));
            videos.Add(video1);

            // --- Video 2 --- //
            Video video2 = new Video("How to Build Clean Object-Oriented Code", "DevArchitects", 1205);
            video2.AddComment(new Comment("Alex", "Exactly what I needed for my university programming assignment."));
            video2.AddComment(new Comment("Emily", "Awesome design tips. My classes look much more cleaner now!"));
            video2.AddComment(new Comment("Frankie", "Loved the practical breakdown of responsibilities."));
            videos.Add(video2);

            // --- Video 3 --- //
            Video video3 = new Video("Top 10 C# Tips and Tricks in 2026", "TechPulse", 450);
            video3.AddComment(new Comment("Henry", "Short, sweet, and incredibly practical. Subscribed!"));
            video3.AddComment(new Comment("Grace", "Wow, I didn't know about that pattern expression feature!"));
            video3.AddComment(new Comment("Hazel", "The third tip saved me lines of boilerplate code."));
            videos.Add(video3);

            foreach (Video video in videos)
            {
                Console.WriteLine("=============================================");
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length}seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.Name} :\"{comment.Text}\"");
                }
                Console.WriteLine();
            }
            Console.WriteLine("====================================================");
        }
    }
}