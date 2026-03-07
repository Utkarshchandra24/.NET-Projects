using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Student.Infrastructure.Data;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _context.users.FirstOrDefault(x => x.Email == request.Email);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            if(user.PasswordHash != request.Password)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Role,
            });

        }


    }
}
