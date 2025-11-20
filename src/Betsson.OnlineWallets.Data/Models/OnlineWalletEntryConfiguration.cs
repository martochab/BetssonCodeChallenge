using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Betsson.OnlineWallets.Data.Models
{
    internal class OnlineWalletEntryConfiguration : IEntityTypeConfiguration<OnlineWalletEntry>
    {
        public void Configure(EntityTypeBuilder<OnlineWalletEntry> builder)
        {   
            builder.HasKey(onlineWalletEntry => onlineWalletEntry.Id);

            builder.Property(ci => ci.Id)
                .IsRequired();
        }
    }
}
