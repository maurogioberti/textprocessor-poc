using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.ResourceAccess.Entities;

namespace Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework
{
    public class PocContext(DbContextOptions<PocContext> options) : DbContext(options)
    {
        public DbSet<TextEntity> Text { get; set; }
        public DbSet<TextSortEntity> TextSort { get; set; }
    }
}