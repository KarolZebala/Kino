using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.ViewModels
{
    public class MovieViewModel
    {
        public long MovieId { get;  set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public MovieReviewViewModel[] ReviewsToAdd { get; set; } = Array.Empty<MovieReviewViewModel>();
        public MovieReviewViewModel[] ReviewsToUpdate { get; set; } = Array.Empty<MovieReviewViewModel>();
        public long[] ReviewsToRemove { get; set; } = Array.Empty<long>();

        public MovieVersionViewModel[] VersionToAdd { get; set; } = Array.Empty<MovieVersionViewModel>();
        public MovieVersionViewModel[] VersionToUpdate { get; set; } = Array.Empty<MovieVersionViewModel>();
        public long[] VersionToRemove { get; set; } = Array.Empty<long>();

        public MovieCommentViewModel[] CommnetToAdd { get; set; } = Array.Empty<MovieCommentViewModel>();
        public MovieCommentViewModel[] CommentToUpdate { get; set; } = Array.Empty<MovieCommentViewModel>();
        public long[] CommentToRemove { get; set; } = Array.Empty<long>();

        public long DirectorId { get; set; }
        public long[] ActorsIds { get; set; } = Array.Empty<long>();
        public long[] ActorsIdsToRemove { get; set; } = Array.Empty<long>();

    }
}
