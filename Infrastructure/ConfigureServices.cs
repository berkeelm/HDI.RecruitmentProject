using Application.Common.Interfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<HDIContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IHDIContext>(provider => provider.GetRequiredService<HDIContext>());

            return services;
        }
    }
}