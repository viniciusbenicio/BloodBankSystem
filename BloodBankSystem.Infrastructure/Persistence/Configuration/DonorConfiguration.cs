using BloodBankSystem.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBankSystem.Infrastructure.Persistence.Configuration
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Address).WithOne(x => x.Donor).HasForeignKey<Address>(x => x.DonorId);
            builder.HasMany(x => x.Donations).WithOne(x => x.Donor).HasForeignKey(x => x.DonorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
