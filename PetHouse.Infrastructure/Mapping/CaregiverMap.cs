using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHouse.Domain.Entities;

namespace PetHouse.Infrastructure.Mapping;

public class CaregiverMap : IEntityTypeConfiguration<Caregiver>
{
    public void Configure(EntityTypeBuilder<Caregiver> builder)
    {
        builder
            .HasOne(x => x.ApplicationUser)
            .WithOne(x => x.Caregiver)
            .HasForeignKey<ApplicationUser>(x => x.CaregiverId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
