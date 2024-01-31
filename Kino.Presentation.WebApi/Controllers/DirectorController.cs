using Kino.Application.Services.Director;
using Kino.Application.Services.RequestModels;
using Kino.Application.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService irectorService)
        {
            _directorService = irectorService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(DirectorViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _directorService.CreateAsync(model, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("director/{directorId}")]
        public async Task<IActionResult> GetById(long directorId, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _directorService.GetByIdAsync(directorId, cancellationToken);
                if (res is null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("directors")]
        public async Task<IActionResult> GetDirectors([FromQuery]DirectorListRequestModel request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _directorService.GetDirectorsAsync(request, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateDirector(DirectorViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _directorService.UpdateAsync(model, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }


}
