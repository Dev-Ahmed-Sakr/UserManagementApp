using DataEntry.Services.Services.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Services.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {

            _userServices = userServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userServices.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userServices.GetById(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }
        // POST: api/users (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] AddUserModel newUser)
        {
            var res = await _userServices.Create(newUser);
            return Ok(res);
        }

        // PUT: api/users/{id} (Admin and Moderator can update)
        [HttpPut]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel updatedUser)
        {
            try
            {
                var user = await _userServices.Update(updatedUser);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // DELETE: api/users/{id} (Admin only)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                var user = await _userServices.Delete(id);
                if (user == null) return NotFound();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
