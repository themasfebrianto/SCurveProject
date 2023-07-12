using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCurveProject.Entities;
using SCurveProject.Services;

namespace SCurveProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserModel user)
        {
            await _userService.CreateUser(user);
            return Ok("success");
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<User>> UpdateUser(string id, UpdateUserModel userModel)
        {
            var existingUser = await _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = userModel.Username;
            existingUser.Password = userModel.Password;
            existingUser.Role = userModel.Role;

            await _userService.UpdateUser(id, existingUser);
            return Ok(existingUser);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var existingUser = await _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}