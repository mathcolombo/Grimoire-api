using Grimoire.Domain.Campaigns.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grimoire.Infrastructure.Campaigns.Configs;

public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("Campaigns");
        
        builder.HasKey(campaign => campaign.Id);
        
        builder.Property(campaign => campaign.Title)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Title of the campaign");
        
        builder.Property(campaign => campaign.Description)
            .IsRequired()
            .HasMaxLength(500)
            .HasComment("Description of the campaign");
        
        builder.Property(campaign => campaign.System)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("System of the campaign");
        
        builder.HasOne(campaign => campaign.DungeonMaster)
            .WithMany(user => user.CampaignsMastered)
            .HasForeignKey(campaign => campaign.DungeonMasterId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(campaign => campaign.Characters)
            .WithOne(character => character.Campaign)
            .HasForeignKey(character => character.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}