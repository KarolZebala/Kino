using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kino.Domain.Movie
{
    public class Movie
    {
        public static Movie CreateNew(
            string movieTitle,
            string descripition
        )
        {
            return new Movie(movieTitle, descripition);
        }
        public long MovieId { get; protected set; }
        public string MovieTitle { get; protected set; }
        public  string Descripition { get; protected set; }
        public Director Director { get; protected set; }
        public IReadOnlyCollection<MovieReview> Reviews 
        { 
            get => _reviews;
            protected set => _reviews = new HashSet<MovieReview>(value);
        }
        protected HashSet<MovieReview> _reviews;

        public IReadOnlyCollection<MovieVersion> MovieVersions
        {
            get => _movieVersions;
            protected set => _movieVersions = new HashSet<MovieVersion>(value);
        }
        protected HashSet<MovieVersion> _movieVersions;

        public IReadOnlyCollection<MovieComment> MovieComents
        {
            get => _movieComments;
            protected set => _movieComments = new HashSet<MovieComment>(value);
        }
        protected HashSet<MovieComment> _movieComments;

        private Movie()
        {
            _reviews = new HashSet<MovieReview>();
            _movieVersions = new HashSet<MovieVersion>();
            _movieComments = new HashSet<MovieComment>();
        }
        private Movie(
            string movieTitle,
            string descripition
        ) : this()
        {
            MovieTitle = movieTitle;
            Descripition = descripition;
        }

        public void ChangeMainAttributes(string movieTitle, string descripiton)
        {
            MovieTitle = movieTitle;
            Descripition = descripiton;
        }
        #region Movie Review
        public void AddMovieReview(
            string author,
            string type,
            string content
        )
        {
            var review = MovieReview.CreateNew(author, type, content);
            _reviews.Add(review);
        }
        public void UpdateMovieReview(long movieReviewId, string content)
        {
            var review = _reviews.FirstOrDefault(x => x.MovieReviewId == movieReviewId);
            if (review is null)
            {
                throw new ArgumentException("Not found review to update");
            }
            review.ChangeMainAttributes(content);
        }
        public void RemoveMovieReview(long movieReviewId)
        {
            var review = _reviews.FirstOrDefault(x => x.MovieReviewId == movieReviewId);
            if (review is null)
            {
                return;
            }
            _reviews.Remove(review);
        }
        #endregion

        #region Director
        public void AddDirector(Director director)
        {
            Director = director;
        }
        #endregion

        #region Movie Version
        public void AddMovieVersion(
            int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            var version = MovieVersion.CreateNew(
                duration: duration,
                soundVersion: soundVersion,
                imageVersion: imageVersion,
                languageVerion: languageVerion,
                hasSubstitles: hasSubstitles
            );
            _movieVersions.Add(version);
        }
        public void UpdateMovieVersion(
            long moviewVersionId,
            int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            var version = _movieVersions.FirstOrDefault(x => x.MovieVersionId == moviewVersionId);
            if(version is null)
            {
                throw new ArgumentException("Not found version to edit");
            }
            version.ChangeMainAttributes(
                duration: duration,
                soundVersion: soundVersion,
                imageVersion: imageVersion,
                languageVerion: languageVerion,
                hasSubstitles: hasSubstitles
            );
        }
        public void RemoveMovieVersion(long movieVersionId)
        {
            var version = _movieVersions.FirstOrDefault(x => x.MovieVersionId == movieVersionId);
            if (version is null)
            {
                return;
            }
            _movieVersions.Remove(version);
        }
        #endregion
    }
    public class Director
    {
        public static Director CreateNew(
            string directorName,
            string directorSurname
        )
        {
            return new Director(directorName, directorSurname);
        }
        public long DirectorId { get; protected set; }
        public string DirectorName { get; protected set; }
        public string DirectorSurname { get; protected set; }
        private Director() { }
        private Director(
            string directorName,
            string directorSurname
        )
        {
            DirectorName = directorName;
            DirectorSurname = directorSurname;
        }
    }
    public class MovieVersion 
    {
        public static MovieVersion CreateNew(int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            return new MovieVersion(
                duration: duration,
                soundVersion: soundVersion,
                imageVersion: imageVersion,
                languageVerion: languageVerion,
                hasSubstitles: hasSubstitles
            );
        }


        public long MovieVersionId { get; protected set; }
        public int Duration { get; protected set; }
        public string SoundVersion { get; protected set; }
        public string ImageVersion { get; protected set; }
        public string LanguageVerion { get; protected set; }
        public bool HasSubstitles { get; protected set; }
        private MovieVersion()
        {

        }
        private MovieVersion(
            int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            Duration = duration;
            SoundVersion = soundVersion;
            ImageVersion = imageVersion;
            LanguageVerion = languageVerion;
            HasSubstitles = hasSubstitles;
        }

        public void ChangeMainAttributes(
            int duration,
            string soundVersion,
            string imageVersion,
            string languageVerion,
            bool hasSubstitles
        )
        {
            Duration = duration;
            SoundVersion = soundVersion;
            ImageVersion = imageVersion;
            LanguageVerion = languageVerion;
            HasSubstitles = hasSubstitles;
        }
    }
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
    public class MovieComment
    {
        public static MovieComment CreateNew(string author, string content) 
        {
            return new MovieComment(author, content);
        }

        public long MovieCommentId { get; protected set; }
        public string Author { get; protected set; }
        public string Content { get; protected set; }
        private MovieComment()
        {

        }
        private MovieComment(string author, string content)
        {
            Author = author;
            Content = content;
        }
    }

}
