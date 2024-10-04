using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        //// GET: api/users (Admin and Moderator can access)
        //[HttpGet]
        //[Authorize(Roles = "Admin,Moderator")]
        //public ActionResult<ResponseDTO<List<User>>> GetUsers()
        //{
        //    var Data = _context.Users.ToList();
        //    ResponseDTO<List<User>> res = new ResponseDTO<List<User>>(Data)
        //    {
        //        Error = null,
        //        Message = "Success"
        //    };
        //    //var users = _context.Users.ToList();
        //    return Ok(res);
        //}
        // GET: api/users (Admin and Moderator can access)
        [HttpGet]
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.Include(u => u.UserType).FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }
        // POST: api/users (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok(newUser);
        }

        // PUT: api/users/{id} (Admin and Moderator can update)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Address = updatedUser.Address;

            _context.SaveChanges();
            return Ok(user);
        }

        // DELETE: api/users/{id} (Admin only)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
