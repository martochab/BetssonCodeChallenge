using Betsson.OnlineWallets.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Betsson.OnlineWallets.Data
{
    internal class OnlineWalletContext : DbContext
    {
        public DbSet<OnlineWalletEntry> Transactions { get; set; }

        public OnlineWalletContext(DbContextOptions<OnlineWalletContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new OnlineWalletEntryConfiguration());
        }
    }
}
