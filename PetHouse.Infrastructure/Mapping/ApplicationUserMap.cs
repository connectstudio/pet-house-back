using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHouse.Domain.Entities;

namespace PetHouse.Infrastructure.Mapping;

public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasOne(x => x.Address)
            .WithOne(x => x.User)
            .HasForeignKey<Address>(x => x.UserId);
    }
}
