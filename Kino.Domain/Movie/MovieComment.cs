namespace Kino.Domain.Movie
{
    public class MovieComment
    {
        public static MovieComment CreateNew(string author, string content) 
        {
            return new MovieComment(author, content);
        }


        public long MovieCommentId { get; protected set; }
        public string Author { get; protected set; }
        public string Content { get; protected set; }
        public long MovieId { get; protected set; }

        private MovieComment()
        {

        }
        private MovieComment(string author, string content)
        {
            Author = author;
            Content = content;
        }
        public void ChangeMainAttributes(string author, string content)
        {
            Author = author;
            Content = content;
        }
    }

}
