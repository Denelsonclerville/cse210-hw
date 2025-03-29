namespace YouTubeVideos
{
    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }  
        private List<Comment> _comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int NumComments()
        {
            return _comments.Count;
        }

        public override string ToString()
        {
            string videoInfo = $"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nNumber of comments: {NumComments()}\nComments:";
            string commentInfo = string.Join("\n", _comments);
            return videoInfo + "\n" + commentInfo;
        }
    }

}