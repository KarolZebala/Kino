using Kino.Application.Services.ViewModels;
using Kino.Domain.Actor.Interfaces;
using Kino.Domain.Director.Interfaces;
using Kino.Domain.Movie;
using Kino.Domain.Movie.Interfaces;
using Kino.Presentation.WebApi.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.Movie
{
    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IActorRepository _actorRepository;
        public MovieService(
            IMovieRepository movieRepository,
            IDirectorRepository directorRepository,
            IActorRepository actorRepository
        )
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _actorRepository = actorRepository;
        }

        public async Task AddMovieComment(MovieCommentViewModel model, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(model.MovieId, cancellationToken);
            if (movie is null)
            {
                throw new ArgumentException($"Not found movie with id: {model.MovieId}");
            }
            movie.AddComment(model.Author, model.Content);
            await _movieRepository.CommitAsync(cancellationToken);
        }

        public async Task AddMovieReview(MovieReviewViewModel model, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(model.MovieId, cancellationToken);
            if(movie is null)
            {
                throw new ArgumentException($"Not found movie with id: {model.MovieId}");
            }
            movie.AddMovieReview(model.Author, model.Type, model.Content);
            await _movieRepository.CommitAsync(cancellationToken);

        }

        public async Task<long> CrateMovieAsync(MovieViewModel model, CancellationToken cancellationToken)
        {
            var movie = Domain.Movie.Movie.CreateNew(model.Title, model.Description);

            var director = await _directorRepository.GetByIdAsync(model.DirectorId, cancellationToken);

            movie.AddDirector(director);

            foreach (var actorId in model.ActorsIds)
            {
                var actor = await _actorRepository.GetByIdAsync(actorId, cancellationToken);
                movie.AddActor(actor);
            }

            foreach (var version in model.VersionToAdd)
            {
                movie.AddMovieVersion(
                    duration: version.Duration,
                    soundVersion: version.SoundVersion,
                    imageVersion: version.ImageVersion,
                    languageVerion: version.LanguageVerion,
                    hasSubstitles: version.HasSubstitles
                );
            }

            foreach (var reviews in model.ReviewsToAdd)
            {
                movie.AddMovieReview(
                    author: reviews.Author,
                    type: reviews.Type,
                    content: reviews.Content
                );
            }

            foreach (var comment in model.CommnetToAdd)
            {
                movie.AddComment(comment.Author, comment.Content);
            }

            await _movieRepository.AddAsync(movie, cancellationToken);
            await _movieRepository.CommitAsync(cancellationToken);
            return movie.MovieId;
        }

        public async Task<IEnumerable<Domain.Movie.Movie>> GetMovies(MovieListRequestModel request, CancellationToken cancellationToken)
        {
            var res = await _movieRepository.GetMoviesAsync(cancellationToken);
            if (!string.IsNullOrWhiteSpace(request.SearchString)) 
            {
                res = res.Where(x => x.MovieTitle.Contains(request.SearchString)
                || x.Descripition.Contains(request.SearchString)
                || x.Director.DirectorName.Contains(request.SearchString)
                || x.Director.DirectorSurname.Contains(request.SearchString)
                );
            }
            res = res.Skip(request.PageIndex.Value).Take(request.PageSize.Value);
            return res;
        }

        public async Task<Domain.Movie.Movie> GetMovoieById(long movieId, CancellationToken cancellationToken)
        {
            var res = await _movieRepository.GetByIdNoTrackingAsync(movieId, cancellationToken);
            return res;
        }

        public async Task<long> UpdateMovieAsync(MovieViewModel model, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(model.MovieId, cancellationToken);
            var director = await _directorRepository.GetByIdAsync(model.DirectorId, cancellationToken);

            movie.AddDirector(director);

            foreach (var actorId in model.ActorsIds)
            {
                var actor = await _actorRepository.GetByIdAsync(actorId, cancellationToken);
                movie.AddActor(actor);
            }


            foreach (var actorId in model.ActorsIdsToRemove)
            {
                var actor = await _actorRepository.GetByIdAsync(actorId, cancellationToken);
                movie.RemoveActor(actor);
            }

            foreach (var version in model.VersionToAdd)
            {
                movie.AddMovieVersion(
                    duration: version.Duration,
                    soundVersion: version.SoundVersion,
                    imageVersion: version.ImageVersion,
                    languageVerion: version.LanguageVerion,
                    hasSubstitles: version.HasSubstitles
                );
            }


            foreach (var version in model.VersionToUpdate)
            {
                movie.UpdateMovieVersion(
                    moviewVersionId: version.MovieVersionId,
                    duration: version.Duration,
                    soundVersion: version.SoundVersion,
                    imageVersion: version.ImageVersion,
                    languageVerion: version.LanguageVerion,
                    hasSubstitles: version.HasSubstitles
                );
            }
            foreach (var version in model.VersionToRemove)
            {
                movie.RemoveMovieVersion(version);
            }

            foreach (var reviews in model.ReviewsToAdd)
            {
                movie.AddMovieReview(
                    author: reviews.Author,
                    type: reviews.Type,
                    content: reviews.Content
                );
            }
            foreach (var reviews in model.ReviewsToUpdate)
            {
                movie.UpdateMovieReview(
                    movieReviewId: reviews.MovieReviewId,
                    content: reviews.Content
                );
            }

            foreach (var reviewsId in model.ReviewsToRemove)
            {
                movie.RemoveMovieReview(reviewsId);
            }

            foreach (var comment in model.CommnetToAdd)
            {
                movie.AddComment(comment.Author, comment.Content);
            }
            
            foreach (var comment in model.CommentToUpdate)
            {
                movie.UpdateComment(
                    movieCommentId: comment.MovieCommentId,
                    author: comment.Author,
                    content: comment.Content
                );
            }
            foreach (var comment in model.CommentToRemove)
            {
                movie.RemoveComment(comment);
            }

            await _movieRepository.CommitAsync(cancellationToken);
            return movie.MovieId;
        }
    }
}
