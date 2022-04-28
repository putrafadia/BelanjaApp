using BelanjaAppIdentityServer.BelanjaApp.Data;
using BelanjaAppIdentityServer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelanjaAppIdentityServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _users;

        public UsersController(IUser users)
        {
            _users = users;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(UserCreateViewModels user)
        {
            try
            {
                await _users.Registration(user);
                return Ok($"Registrasi user {user.UserName} berhasil");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]

        public IEnumerable<UserViewModels> GetAllUsers()
        {
            return _users.GetAllUsers();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserViewModels>> Authentication(UserCreateViewModels createUser)
        {
            try
            {
                var user = await _users.Authenticate(createUser.UserName, createUser.Password);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error : {ex.Message}");
            }
        }
    }
}
