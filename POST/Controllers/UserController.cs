using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POST.Models;
using POST.Repositories;

namespace POST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo) {
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

            return Unauthorized();
        }
        [HttpPost("signin")]
        public async Task<IActionResult> signIn(SigninModel model)
        {
            var result = await _repo.SigninAsync(model);

            if(string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
