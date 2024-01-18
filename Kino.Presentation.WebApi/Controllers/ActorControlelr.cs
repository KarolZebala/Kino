using Kino.Application.Services.Actor;
using Kino.Application.Services.ViewModels;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;

namespace Kino.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ActorViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _actorService.CreateAsync(model, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
            }
        }
        [HttpGet("actor")]
        public async Task<IActionResult> GetActor(long actorId, CancellationToken cancellationToken)
        {
            try
            {
                var actor = await _actorService.GetByIdAsync(actorId, cancellationToken);
                if(actor is null)
                {
                    return NotFound(actor);
                }
                return Ok(actor);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("actors")]
        public async Task<IActionResult> GetActors(CancellationToken cancellationToken)
        {
            try
            {
                var actors = await _actorService.GetActorsAsync(cancellationToken);
                return Ok(actors);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateActor(ActorViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _actorService.UpdateAsync(model, cancellationToken);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
