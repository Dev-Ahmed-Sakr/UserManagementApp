using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Services.Models;

namespace DataEntry.Services.Services.Authentication;



public class AuthService : IAuthService
{
    private readonly UserContext _context;
    private readonly IConfiguration _configuration;


    public AuthService(UserContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public async Task<ResponseDTO<string>> LoginAsync(UserLoginModel loginUser)
    {
        try
        {
            var user = await _context.Users.Include(u => u.UserType).SingleOrDefaultAsync(u => u.Email == loginUser.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
            {
                // Password is valid, generate JWT token
                return new ResponseDTO<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = "Failed to login"
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.UserIdentifier.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.UserType.Name)
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new  ResponseDTO<string>
            {
                Data = tokenString,
                IsSuccess = true,
                Message = ""
            };
        }
        catch (Exception)
        {
            return new ResponseDTO<string>
            {
                Data = "",
                IsSuccess = false,
                Message = "Failed to login"
            };
        }
    }

}

