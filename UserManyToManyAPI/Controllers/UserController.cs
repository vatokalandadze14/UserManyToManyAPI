using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManyToManyAPI.Models;
using UserManyToManyAPI.Services.UserService;

namespace UserManyToManyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await userService.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(await userService.GetSingleUser(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            return Ok(await userService.AddUser(user));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User user)
        {
            return Ok(await userService.UpdateUser(id, user));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            return Ok(await userService.DeleteUser(id));
        }
    }
}
