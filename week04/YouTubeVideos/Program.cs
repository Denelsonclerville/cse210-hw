using System;
using System.Collections.Generic;
using YouTubeVideos;

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Economi","Etzer Emile",100);
        Video video2 = new Video("Riz Djondjon","Emilie Cuisine",150);
        Video video3 = new Video("Cinema","Phillipe Jean L",200);


        Comment comment1 = new Comment("Jean-Pierre", "Mwen aprann anpil nan videyo sa a. Mèsi anpil!");
        Comment comment2 = new Comment("Mireille", "Videyo a se yon bèl travay! M'ap tann pwochen an!");
        Comment comment3 = new Comment("Claudine", "Sa a se yon bèl eksplike, m'ap swete w'ap fè plis videyo konsa.");

        Comment comment4 = new Comment("Frantz", "Mwen eseye resèt sa a, e li soti byen! Mèsi pou pataje.");
        Comment comment5 = new Comment("Emmanuelle", "Sa se yon bèl videyo! Koulye a, mwen ka kwit yon pasta san pwoblèm.");
        Comment comment6 = new Comment("Bertrand", "Sa a te trè fasil pou swiv, mwen renmen li!");

        Comment comment7 = new Comment("Michel", "Videyo sa a fè m' anvi ale nan peyi Islann!");
        Comment comment8 = new Comment("Simone", "Peyizaj yo bèl anpil, mwen pa ka tann pou m' ale la.");
        Comment comment9 = new Comment("Jocelyne", "Videyo a se yon eksperyans, mwen santi m' tankou m' te la avèk ou.");

        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);

        video2.AddComment(comment4);
        video2.AddComment(comment5);
        video2.AddComment(comment6);

        video3.AddComment(comment7);
        video3.AddComment(comment8);
        video3.AddComment(comment9);

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine(new string('-', 40));
        }
    }
}
