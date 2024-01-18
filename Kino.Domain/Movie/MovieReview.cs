namespace Kino.Domain.Movie
{
    public class MovieReview
    {
        public static MovieReview CreateNew(string author,
            string type,
            string content
        )
        {
            return new MovieReview(author, type, content);
        }

        public long MovieReviewId { get; protected set; }
        public string Author { get; protected set; }
        public string Type { get; protected set; }
        public string Content { get; protected set; }
        public long MovieId { get; protected set; }

        private MovieReview() { }
        private MovieReview(
            string author,
            string type,
            string content
        )
        {
            Author = author;
            Type = type;
            Content = content;
        }
        public void ChangeMainAttributes(string content)
        {
            Content = content.Trim();
        }
    }

}
