using BloodBankSystem.Core;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BloodBankSystem.Infrastructure.Entities.Persistence;

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
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
