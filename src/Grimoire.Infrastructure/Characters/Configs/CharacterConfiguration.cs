using Grimoire.Domain.Characters.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grimoire.Infrastructure.Characters.Configs;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Characters");
        
        builder.HasKey(character => character.Id);
        
        builder.Property(character => character.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Name of the character");
        
        builder.Property(character => character.System)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Name of the RPG system for which the character sheet was created.");
        
        builder.Property(character => character.Class)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Name of the character class chosen in the RPG system.");

        builder.Property(character => character.Level)
            .IsRequired()
            .HasComment("Level of the character");
        
        builder.Property(character => character.Bio)
            .HasMaxLength(500)
            .HasComment("Biography/Background of the character");

        builder.Property(character => character.Attributes)
            .HasColumnType("jsonb")
            .HasComment("Character Attribute Points");
        
        builder.HasOne(character => character.Player)
            .WithMany(user => user.Characters)
            .HasForeignKey(character => character.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(character => character.Campaign)
            .WithMany(campaign => campaign.Characters)
            .HasForeignKey(character => character.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}