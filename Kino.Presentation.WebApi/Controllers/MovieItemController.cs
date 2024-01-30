using Kino.Application.Services.MovieItem;
using Kino.Application.Services.RequestModels;
using Kino.Application.Services.ViewModels;
using Kino.Domain.MovieItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Kino.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieItemController : ControllerBase
    {
        private readonly IMovieItemService _movieItemService;

        public MovieItemController(IMovieItemService movieItemService)
        {
            _movieItemService = movieItemService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> AddMovieItem(MovieItemViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _movieItemService.AddMovieItemAsync(model, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("movieItems")]
        public async Task<IActionResult> GetMovieItems([FromQuery] MovieItemListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _movieItemService.GetMovieItemsAsync(request, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("movieItem/{movieItemid}")]
        public async Task<IActionResult> GetMovieItem(long movieItemid, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _movieItemService.GetMovieItemById(movieItemid, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMovieItem(MovieItemViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _movieItemService.UpdateMovieItemAsync(model, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
