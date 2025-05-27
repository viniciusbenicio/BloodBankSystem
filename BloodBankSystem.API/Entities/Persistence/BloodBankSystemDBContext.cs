using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.API.Entities.Persistence
{
    public class BloodBankSystemDBContext : DbContext
    {
        public BloodBankSystemDBContext(DbContextOptions<BloodBankSystemDBContext> options) : base(options)
        {

        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Donor>(d =>
            {
                d.HasKey(x => x.Id);
                //d.HasOne(x => x.Address).WithOne(x => x.Donor).HasForeignKey<Address>(x => x.DonorId).IsRequired(false);
                //d.HasMany(x => x.Donations).WithOne(x => x.Donor).HasForeignKey(x => x.DonorId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            });

            base.OnModelCreating(builder);
        }

    }
}
