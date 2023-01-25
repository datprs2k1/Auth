using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POST.Data;
using POST.Models;
using POST.Repositories;
using System.Security.Claims;

namespace POST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> signUp(SignupModel model)
        {
            var result = await _repo.SignUpAsync(model);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized(result.Errors);
        }
        [HttpPost("signin")]
        public async Task<IActionResult> signIn(SigninModel model)
        {
            var result = await _repo.SigninAsync(model);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> getCurrentUser()
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                var email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                var user = await _repo.GetUserAsync(email);

                return Ok(user);
            }

            return BadRequest();
        }
    }
}
