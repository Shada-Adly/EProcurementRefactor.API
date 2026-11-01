using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.DTOs.SapDTOs;
using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Infrastructure.DBContexts;
using EProcurementRefactor.Infrastructure.Reposetories;
using EProcurementRefactor.Infrastructure.Services;
using EProcurementRefactor.Infrastructure.Services.SapServices.PackagesServices;
using EProcurementRefactor.Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EProcurementRefactor.Infrastructure.Extenions
{
    public static class InfarstructureServices
    {
        public static void AddInfarstructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DefaultConnectionString"); 

            services.Configure<TokenSettings>(
                configuration.GetSection("TokenSettings")
            );

            services.Configure<SapIntegration>(
                configuration.GetSection("SapIntegration")
            );

            services.AddDbContext<EprocurementDbContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                ).LogTo(
        Console.WriteLine,
        LogLevel.Information
    )
                .UseSnakeCaseNamingConvention();
            });

            services.AddSingleton<IJWTGenerator, JwtTokenGenerator>();
            services.AddSingleton<IPasswordService, PasswordService>();

            services.AddScoped(typeof(IGenericPackagesRepo<>), typeof(GenericPackageRepo<>));
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IGenericGetSapPackageLinesService, GenericGetSapPackageLinesService>();
            services.AddScoped<ICreatePackageService, CreatePackageService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}