using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetHouse.Domain.Entities;
using PetHouse.Infrastructure.Mapping;

namespace PetHouse.Infrastructure.Context;

public class PetHouseDbContext : IdentityDbContext<ApplicationUser>
{
    public PetHouseDbContext(DbContextOptions options) : base(options) { }

    public DbSet<ApplicationUser> applicationUser { get; set; }
    public DbSet<Caregiver> caregiver { get; set; }
    public DbSet<PetServices> petServices { get; set; }
    public DbSet<Address> addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new CaregiverMap()); 
        
        modelBuilder
            .ApplyConfiguration(new ApplicationUserMap());

        base.OnModelCreating(modelBuilder);
    }

}
