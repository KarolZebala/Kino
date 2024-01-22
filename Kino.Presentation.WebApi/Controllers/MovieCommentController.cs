using Kino.Application.Services.Movie;
using Kino.Application.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieCommentController : ControllerBase
    {
        private readonly IMovieService _movieServie;

        public MovieCommentController(IMovieService movieServie)
        {
            _movieServie = movieServie;
        }
        [HttpPost("create")]
        public async Task<IActionResult> AddMovieComment(MovieCommentViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                await _movieServie.AddMovieComment(model, cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
