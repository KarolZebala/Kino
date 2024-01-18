namespace Kino.Domain.Actor
{
    public class Actor
    {
        public static Actor CreateNew(
            string actorName,
            string actorSurname
        )
        {
            return new Actor(actorName, actorSurname);
        }
        public long ActorId { get; protected set; }
        public string ActorName { get; protected set; }
        public string ActorSurname { get; protected set; }
        public IReadOnlyCollection<Movie.Movie> Movies
        {
            get => _movies;
            protected set => _movies = new HashSet<Movie.Movie>(value);
        }
        protected HashSet<Movie.Movie> _movies;
        private Actor() 
        {
            _movies = new HashSet<Movie.Movie>();
        }
        private Actor(
            string actorName,
            string actorSurname
        ):this()
        {
            ActorName = actorName;
            ActorSurname = actorSurname;
        }

        public void ChangeMainAttributes(
            string actorName,
            string actorSurname
        )
        {
            ActorName = actorName;
            ActorSurname = actorSurname;
        }
    }

}
