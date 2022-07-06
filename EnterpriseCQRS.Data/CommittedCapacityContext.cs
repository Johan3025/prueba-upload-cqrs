using EnterpriseCQRS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseCQRS.Data
{
    public class CommittedCapacityContext : DbContext
    {
        public CommittedCapacityContext( DbContextOptions<CommittedCapacityContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
