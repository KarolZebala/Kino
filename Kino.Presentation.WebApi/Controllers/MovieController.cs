using Kino.Application.Services.Movie;
using Kino.Application.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(MovieViewModel model, CancellationToken cancellationToken) 
        {
            try
            {
                var res = await _movieService.CrateMovieAsync(model, cancellationToken);
                return Ok($"Created with id: {res}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetById(long movieId, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _movieService.GetMovoieById(movieId, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("movies")]
        public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
        {
            try
            {
                var res = await _movieService.GetMovies(cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMovie(MovieViewModel model,CancellationToken cancellationToken)
        {
            try
            {
                var res = await _movieService.UpdateMovieAsync(model, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
