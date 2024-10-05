using DataEntry.Services.Services.Authentication;
using DataEntry.Services.Services.UserRepository;

namespace DataEntry.RegisterServices
{
    public static class ServicesExtentions
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IIdentityUserService, IdentityUserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }

}
