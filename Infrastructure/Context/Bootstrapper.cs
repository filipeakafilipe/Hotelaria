using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Hotelaria.Infrastructure.Context
{
    public static class Bootstrapper
    {
        public static IServiceCollection UseFinancialDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<HotelariaDbContext>(config => config.UseSqlServer(configuration.GetConnectionString("HotelariaDbContext")));
        }
    }
}
