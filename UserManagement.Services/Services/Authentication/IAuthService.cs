using UserManagement.Services.Models;

namespace DataEntry.Services.Services.Authentication;

public interface IAuthService
{
    Task<ResponseDTO<string>> LoginAsync(UserLoginModel loginUser);
}
