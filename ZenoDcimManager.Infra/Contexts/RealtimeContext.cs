using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Contexts
{
    public class RealtimeContext : DbContext
    {
        public RealtimeContext(DbContextOptions<RealtimeContext> options) : base(options)
        {

        }

        // public DbSet<> MyProperty { get; set; }
    }
}