using Kino.Application.Services.Movie;
using Kino.Application.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieReviewController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieReviewController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddReview(MovieReviewViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                await _movieService.AddMovieReview(model, cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
