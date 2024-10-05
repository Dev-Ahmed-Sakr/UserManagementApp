namespace DataEntry.Services.Services.Authentication;



public class AuthService : IAuthService
{
    //private readonly UserManager<User> _userManager;
    //private readonly SignInManager<User> _signInManager;
    //private readonly IOptions<ApplicationSettings> _appSettings;

    //public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<ApplicationSettings> appSettings)
    //{
    //    _userManager = userManager;
    //    _signInManager = signInManager;
    //    _appSettings = appSettings;
    //}

    //public async Task<ResponseDTO<LoginDTO>> LoginAsync(string username, string password)
    //{
    //    ResponseDTO<LoginDTO> generalDTO = new(null);
    //    try
    //    {
    //        User? user = null;
    //        if (!string.IsNullOrEmpty(username))
    //        {
    //            user = await _userManager.Users.Where(x => x.UserName == username)
    //                                            .Include(x => x.UserType)
    //                                            .Include(x => x.Country)
    //                                            .Include(x => x.Company)
    //                                            .FirstOrDefaultAsync();

    //        }
    //        if (user is null)
    //        {
    //            generalDTO.Error = new()
    //            {
    //                ErrorCode = 404,
    //                Message = "User Not Found"
    //            };
    //            return generalDTO;

    //        }


    //        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
    //        if (result.Succeeded)
    //        {
    //            SymmetricSecurityKey? secretKey = new(Encoding.UTF8.GetBytes(_appSettings.Value.JWT_Secret));
    //            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
    //            IList<string> roles = await _userManager.GetRolesAsync(user);
    //            List<Claim> Claims = new();

    //            // Add roles as multiple claims
    //            foreach (var role in roles)
    //            {
    //                Claims.Add(new Claim("Roles", role));
    //                Claims.Add(new Claim(ClaimTypes.Role, role));
    //            }

    //            Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
    //            Claims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
    //            Claims.Add(new Claim(ClaimTypes.Email, user.Email));
    //            Claims.Add(new Claim(ClaimTypes.Name, user.Name));

    //            Claims.Add(new Claim("UserId", user.Id));
    //            Claims.Add(new Claim("UserName", user.UserName));
    //            Claims.Add(new Claim("UserTypeId", user.UserTypeId.ToString()));
    //            Claims.Add(new Claim("Email", user.Email));
    //            Claims.Add(new Claim("Name", user.Name));
    //            Claims.Add(new Claim("LocationId", user.LocationId.HasValue ? user.LocationId.Value.ToString() : string.Empty));
    //            Claims.Add(new Claim("CompanyId", user.CompanyId.HasValue ? user.CompanyId.Value.ToString() : string.Empty));

    //            JwtSecurityToken tokeOptions = new(
    //                                                issuer: _appSettings.Value.Issuer,
    //                                                audience: _appSettings.Value.Audience,
    //                                                claims: Claims.ToList(),
    //                                                expires: DateTime.Now.AddDays(1),
    //                                                signingCredentials: signinCredentials
    //                                                );
    //            string? Token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
    //            generalDTO = new(new LoginDTO()
    //            {
    //                IsFirstLogin = user.IsFirstLogin,
    //                Token = Token
    //            })
    //            {
    //                Message = "User logged in successfully"
    //            };
    //        }
    //        else
    //        {
    //            generalDTO.Error = new()
    //            {
    //                ErrorCode = 404,
    //                Message = "User Not Found"
    //            };
    //            return generalDTO;
    //        }

    //        return generalDTO;
    //    }
    //    catch (Exception ex)
    //    {
    //        generalDTO.Error = new()
    //        {
    //            ErrorCode = 404,
    //            Message = "Failed"
    //        };
    //        return generalDTO;
    //    }

    //}

    //public async Task<ResponseDTO<bool>> ChangePasswordAsync(string username, string currentPassword, string newPassword)
    //{
    //    var user = await _userManager.FindByNameAsync(username);
    //    if (user == null)
    //    {
    //        return new ResponseDTO<bool>(false) { Error = new ErrorDTO { ErrorCode = 404, Message = "User Not Found " }, Message = "Failed" };
    //    }
    //    user.IsFirstLogin = false;
    //    var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    //    return new ResponseDTO<bool>(result.Succeeded)
    //    {
    //        Message = "Success"
    //    };

    //}
}

