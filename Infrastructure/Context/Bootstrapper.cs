using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Hotelaria.Infrastructure.Context
{
    public static class Bootstrapper
    {
        public static IServiceCollection UseHotelariaDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelariaContext>(config => config.UseSqlServer(configuration.GetConnectionString("HotelariaDbContext")));

            return services;
        }
    }
}
