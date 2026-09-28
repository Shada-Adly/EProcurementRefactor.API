using EProcurementRefactor.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EProcurementRefactor.Infrastructure.Extenions
{
    public static class InfarstructureServices
    {
        public static void AddInfarstructureServices(
            this IServiceCollection Services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefualtConnectionString");

            Services.AddDbContext<EProcurementDbContext>(options =>
            {
                Services.AddDbContext<EProcurementDbContext>(
                 options => options.UseMySql(connectionString,
                 ServerVersion.AutoDetect(connectionString))
                 .UseSnakeCaseNamingConvention());
            });
        }
    }
}

