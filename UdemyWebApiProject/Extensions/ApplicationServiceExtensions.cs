using Microsoft.EntityFrameworkCore;
using UdemyWebApiProject.Data;
using UdemyWebApiProject.Interfaces;
using UdemyWebApiProject.Services;

namespace UdemyWebApiProject.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                var connectionString = config.GetConnectionString("DefaultConnectionString");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
