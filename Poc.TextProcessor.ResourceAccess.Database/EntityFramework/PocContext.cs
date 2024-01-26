using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.ResourceAccess.Entities;

namespace Poc.TextProcessor.ResourceAccess.Database.EntityFramework
{
    public class PocContext : DbContext
    {
        public PocContext(DbContextOptions<PocContext> options)
            : base(options)
        {
        }

        public DbSet<TextEntity> Text { get; set; }
        public DbSet<TextSortEntity> TextSort { get; set; }
    }
}