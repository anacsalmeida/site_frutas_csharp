using FrutasCitricas.Models;
using Microsoft.EntityFrameworkCore;

namespace FrutasCitricas.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }
        public DbSet<FrutasModel> Frutas { get; set; }
    }
}
