using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IJwtTokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok("Register Succesed");
                }
                return BadRequest(result.Errors);
            }

            return BadRequest();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Authenticate user (check credentials, etc.)
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = _tokenGenerator.GenerateJwtToken(user); 
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
