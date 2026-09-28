using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Infrastructure.DBContexts;
using EProcurementRefactor.Infrastructure.Reposetories;
using EProcurementRefactor.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EProcurementRefactor.Infrastructure.Extenions
{
    public static class InfarstructureServices
    {
        public static void AddInfarstructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DefualtConnectionString");

            services.AddDbContext<EprocurementDbContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                )
                .UseSnakeCaseNamingConvention();
            });

            services.AddSingleton<IjwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IPasswordService, PasswordService>();

            services.AddScoped<IAdminRepository, AdminRepository>();

            services.Configure<TokenSettings>(
                configuration.GetSection("TokenSettings")
            );
        }
    }
}