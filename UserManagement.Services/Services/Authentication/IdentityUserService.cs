using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DataEntry.Services.Services.Authentication;

public class IdentityUserService : IIdentityUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public IdentityUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Guid GetUserID() => !string.IsNullOrEmpty(_contextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value) ? Guid.Parse(_contextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value) : new Guid();

}
