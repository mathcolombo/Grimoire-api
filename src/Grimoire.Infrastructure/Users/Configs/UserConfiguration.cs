using Grimoire.Domain.Shared.ValueObjects;
using Grimoire.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grimoire.Infrastructure.Users.Configs;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(user => user.Id);
        
        builder.Property(user => user.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Full name of the user");
        
        builder.Property(user => user.Email)
            .HasConversion(
                email => email.Address,
                str=> Email.Create(str)
            )
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("Email address of the user");
        builder.HasIndex(user => user.Email).IsUnique();
    }
}