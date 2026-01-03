using Microsoft.AspNetCore.Identity;
using MovieApi.Persistance.Context;
using MovieApi.Persistance.Identity;

namespace MovieApi.WebApi.Extensions
{
    public static class IdentityExtensions
    {


        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            //add identity
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>();

            return services;
        }
    }
}
