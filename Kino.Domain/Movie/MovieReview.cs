namespace Kino.Domain.Movie
{
    public class MovieReview
    {
        public static MovieReview CreateNew(string author,
            string type,
            string content,
            int grade
        )
        {
            return new MovieReview(author, type, content, grade);
        }

        public long MovieReviewId { get; protected set; }
        public string Author { get; protected set; }
        public string Type { get; protected set; }
        public string Content { get; protected set; }
        public int Grade { get; set; }
        public long MovieId { get; protected set; }

        private MovieReview() { }
        private MovieReview(
            string author,
            string type,
            string content,
            int grade
        )
        {
            Author = author;
            Type = type;
            Content = content.Trim();
            Grade = grade;
        }
        public void ChangeMainAttributes(string content)
        {
            Content = content.Trim();
        }
    }

}
