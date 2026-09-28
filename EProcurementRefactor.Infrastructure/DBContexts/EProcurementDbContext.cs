using Microsoft.EntityFrameworkCore;

namespace EProcurementRefactor.Infrastructure.DBContexts
{
    public class EProcurementDbContext:DbContext
    {
        public EProcurementDbContext(DbContextOptions<EProcurementDbContext> options):base(options)
        {
            
        }
    }
}
