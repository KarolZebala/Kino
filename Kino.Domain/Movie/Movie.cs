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
        public Director.Director Director { get; protected set; }
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
        public IReadOnlyCollection<Actor.Actor> Actors
        {
            get => _actors;
            protected set => _actors = new HashSet<Actor.Actor>(value);
        }
        protected HashSet<Actor.Actor> _actors;

        private Movie()
        {
            _reviews = new HashSet<MovieReview>();
            _movieVersions = new HashSet<MovieVersion>();
            _movieComments = new HashSet<MovieComment>();
            _actors = new HashSet<Actor.Actor>(); 
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
            string content,
            int grade
        )
        {
            var review = MovieReview.CreateNew(author, type, content, grade);
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
        public void AddDirector(Director.Director director)
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

        #region Movie Commnets
        public void AddComment(string author, string content) 
        {
            var comment = MovieComment.CreateNew(author, content);
            _movieComments.Add(comment);
        }
        public void UpdateComment(long movieCommentId, string author, string content)
        {
            var comment = _movieComments.FirstOrDefault(x => x.MovieCommentId == movieCommentId);
            if(comment is null)
            {
                throw new ArgumentException("Not found comment");
            }
            comment.ChangeMainAttributes(author, content);
        }
        public void RemoveComment(long movieCommentId)
        {
            var comment = _movieComments.FirstOrDefault(x => x.MovieCommentId == movieCommentId);
            if (comment is null)
            {
                return;
            }
            _movieComments.Remove(comment);
        }
        #endregion

        #region Actors
        public void AddActor(Actor.Actor actor) 
        {
            _actors.Add(actor);
        }
        public void RemoveActor(Actor.Actor actor)
        {
            _actors.Remove(actor);
        }
        #endregion

    }

}
